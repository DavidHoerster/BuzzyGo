using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.WindowsAzure;
using Ncqrs.Commanding;

namespace BuzzyGo.Web.Utility
{
    public class CloudHelper
    {
        private static bool _storageInitialized = false;
        private static object _locker = new Object();
        private static CloudBlobClient _blobStorage = null;
        private static CloudQueueClient _queueStorage = null;

        public static CloudQueueClient QueueStorage
        {
            get
            {
                if (_queueStorage == null)
                {
                    Init();
                }
                return _queueStorage;
            }
        }

        public static CloudBlobClient BlobStorage
        {
            get
            {
                if (_blobStorage == null)
                {
                    Init();
                }
                return _blobStorage;
            }
        }

        private static void Init()
        {
            Microsoft.WindowsAzure.CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
            {
                configSetter(Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetConfigurationSettingValue(configName));
            });

            InitializeStorage();
        }

        protected static Boolean AddObjectToBlobStorage(String blobName, String blobContainer, Object blobToAdd)
        {
            bool blobUploadSuccessful = false;
            CloudBlobContainer container = BlobStorage.GetContainerReference(blobContainer);
            CloudBlockBlob theBlob = container.GetBlockBlobReference(blobName);

            using (MemoryStream msBlob = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(msBlob, blobToAdd);
                byte[] blobBytes = msBlob.ToArray();
                theBlob.UploadByteArray(blobBytes);
                blobUploadSuccessful = true;
            }

            return blobUploadSuccessful;
        }

        protected static Boolean AddMessageToQueue(String message, String queueContainer)
        {
            Boolean queueInsertSuccessful = false;
            try
            {
                var queue = QueueStorage.GetQueueReference(queueContainer);
                var msg = new CloudQueueMessage(message);
                queue.AddMessage(msg);
                queueInsertSuccessful = true;
            }
            catch (ApplicationException aexc)
            {
                System.Diagnostics.Trace.TraceInformation("Didn't add {0} to queue -- {1}", message, aexc.Message);
            }

            return queueInsertSuccessful;
        }

        public static Boolean EnqueueCommand(ICommand commandToIssue)
        {
            Guid commandBlobGuid = Guid.NewGuid();
            String commandBlobSourceString = commandBlobGuid.ToString();
            String queueMessage = commandBlobSourceString + ":" + commandToIssue.GetType().AssemblyQualifiedName;
            Boolean enqueueSuccessful = false;

            if (AddObjectToBlobStorage(commandBlobSourceString, "commands", commandToIssue))
            {
                System.Diagnostics.Trace.TraceInformation("Added command to blob storage as {0}", commandBlobSourceString);
                if (AddMessageToQueue(queueMessage, "commandmessages"))
                {
                    System.Diagnostics.Trace.TraceInformation("Added {0} to queue", queueMessage);
                    enqueueSuccessful = true;
                }
            }

            return enqueueSuccessful;
        }

        public static Boolean LogMessage(Int64 userID, String message, String messageType)
        {
            Boolean logSuccessful = false;
            Guid logSourceID = Guid.NewGuid();
            String logSourceString = logSourceID.ToString();

            BuzzyGo.Commands.Logging.LogCommand theLog = new BuzzyGo.Commands.Logging.LogCommand()
            {
                LogSourceID = logSourceID,
                Message = message,
                UserID = userID,
                MessageType = messageType,
                LogTime = Ncqrs.NcqrsEnvironment.Get<Ncqrs.IClock>().UtcNow()
            };

            if (AddObjectToBlobStorage(logSourceString, "logitems", theLog))
            {
                System.Diagnostics.Trace.TraceInformation("Added message from {0} to blob storage as {1}", userID.ToString(), logSourceID);
                if (AddMessageToQueue(logSourceString, "logmessages"))
                {
                    System.Diagnostics.Trace.TraceInformation("Added {0} to queue", logSourceID);
                    logSuccessful = true;
                }
            }

            return logSuccessful;
        }

        private static void InitializeStorage()
        {
            if (_storageInitialized)
            {
                return;
            }

            lock (_locker)
            {
                try
                {
                    var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");

                    _blobStorage = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = _blobStorage.GetContainerReference("logitems");
                    blobContainer.CreateIfNotExist();

                    _queueStorage = storageAccount.CreateCloudQueueClient();
                    CloudQueue queue = _queueStorage.GetQueueReference("logmessages");
                    queue.CreateIfNotExist();
                }
                catch (System.Net.WebException)
                {
                    throw new System.Net.WebException("Storage services initialization failure. "
                        + "Check your storage account configuration settings. If running locally, "
                        + "ensure that the Development Storage service is running.");

                }

                _storageInitialized = true;
            }
        }
    }
}
