using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

using Ncqrs;
using Ncqrs.Commanding.ServiceModel;
using Ncqrs.Commanding.CommandExecution.Mapping;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Eventing.ServiceModel.Bus;
using Ncqrs.Eventing.Storage;
using Ncqrs.Eventing.Storage.SQL;

//using BrainCredits.Denormalizers.Lesson;
//using BrainCredits.Command.Lesson;

//using StructureMap;
//using StructureMap.Configuration.DSL;

namespace BuzzyGo.QueueWorker
{
    public class QueueMonitor : RoleEntryPoint
    {
        private static ICommandService _service;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("WorkerRole1 entry point called", "Information");

            //Timer logTimer = new Timer(new TimerCallback(LogWorker.LogQueuePoller), null, 0, 10000);
            while (true)
            {

                try
                {
                    CommandWorker.CommandQueuePoller(_service);
                    Thread.Sleep(2000);     //sleep for 2 seconds
                }
                catch (Exception e)
                {
                    Trace.WriteLine("Error occurred: " + e.Message);
                    if (e.InnerException!=null)
                    {
                        Trace.WriteLine("Additional error message: " + e.InnerException.Message);
                        Trace.WriteLine("Stack: " + e.InnerException.StackTrace);
                    }
                }
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) => configSetter(RoleEnvironment.GetConfigurationSettingValue(configName)));
            CloudStorageAccount storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");

            InitializeStorageResources(storageAccount);

            InitializeEventingService();

            _service = NcqrsEnvironment.Get<ICommandService>();

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        private static void InitializeStorageResources(CloudStorageAccount storageAccount)
        {
            var blobStorage = storageAccount.CreateCloudBlobClient();
            //LogWorker.LogBlobContainer = blobStorage.GetContainerReference("logitems");
            CommandWorker.CommandBlobContainer = blobStorage.GetContainerReference("commands");

            var queueStorage = storageAccount.CreateCloudQueueClient();
            //LogWorker.LogQueue = queueStorage.GetQueueReference("logmessages");
            CommandWorker.CommandQueue = queueStorage.GetQueueReference("commandmessages");

            bool isStorageFinalized = false;
            while (!isStorageFinalized)
            {
                try
                {
                    //LogWorker.LogBlobContainer.CreateIfNotExist();
                    //LogWorker.LogQueue.CreateIfNotExist();
                    CommandWorker.CommandBlobContainer.CreateIfNotExist();
                    CommandWorker.CommandQueue.CreateIfNotExist();

                    isStorageFinalized = true;
                }
                catch (StorageClientException sce)
                {
                    if (sce.ErrorCode == StorageErrorCode.TransportError)
                    {
                        Trace.TraceError("Storage services initialization failure.  " +
                            "Check your storage account configuration settings.  " +
                            "If running locally, ensure that the Development Storage service is running.  " +
                            "Message: '{0}'", sce.Message);
                    }
                    else
                    {
                        throw sce;
                    }
                }
            }
        }

        private static void InitializeEventingService()
        {
            NcqrsEnvironment.SetDefault<ICommandService>(InitializeCommandService());
            NcqrsEnvironment.SetDefault<IEventBus>(InitializeEventBus());
            NcqrsEnvironment.SetDefault<IEventStore>(InitializeEventStore());

            //ObjectFactory.Initialize(x =>
            //{
            //    x.AddRegistry<DIContainerRegistry>();
            //});

        }

        private static IEventStore InitializeEventStore()
        {
            var store = new MsSqlServerEventStore(RoleEnvironment.GetConfigurationSettingValue("EventStoreConnectionString"));
            return store;
        }

        private static IEventBus InitializeEventBus()
        {
            var bus = new InProcessEventBus();

            //TODO: need to register handlers here!!
            //bus.RegisterAllHandlersInAssembly(typeof(LessonDenormalizer).Assembly);

            return bus;
        }

        private static ICommandService InitializeCommandService()
        {
            var service = new Ncqrs.Commanding.ServiceModel.CommandService();

            try
            {
                //TODO: need to register assembly here!!
                //var commandAssembly = typeof(ViewLesson).Assembly;
                //service.RegisterExecutorsInAssembly(commandAssembly);
            }
            catch (ApplicationException exc)
            {
                Console.WriteLine(exc.Message);
            }

            return service;
        }

    }

    //public class DIContainerRegistry : Registry
    //{
    //    public DIContainerRegistry()
    //    {
    //        For<BrainCredits.Utilities.IEmailService>()
    //            .Use<BrainCredits.Utilities.SendGridEmailService>();
    //        For<BrainCredits.Repository.ILessonRepository>()
    //            .Use<BrainCredits.Repository.LinqToSql.LessonLinqRepository>();
    //        For<BrainCredits.Repository.IUserRepository>()
    //            .Use<BrainCredits.Repository.LinqToSql.UserLinqRepository>();
    //        For<BrainCredits.Repository.ITranscriptRepository>()
    //            .Use<BrainCredits.Repository.LinqToSql.TranscriptLinqRepository>();
    //        For<BrainCredits.Repository.IPublisherRepository>()
    //            .Use<BrainCredits.Repository.LinqToSql.PublisherLinqRepository>();
    //        For<BrainCredits.Repository.IEventRepository>()
    //            .Use<BrainCredits.Repository.LinqToSql.EventLinqRepository>();
    //    }
    //}
}
