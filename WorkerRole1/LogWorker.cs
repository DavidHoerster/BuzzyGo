using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BuzzyGo.QueueWorker
{
    public static class LogWorker
    {
        private static CloudQueue _logQueue;
        public static CloudQueue LogQueue
        {
            get
            {
                return _logQueue;
            }
            internal set
            {
                _logQueue = value;
            }
        }

        private static CloudBlobContainer _logBlobContainer;
        public static CloudBlobContainer LogBlobContainer
        {
            get
            {
                return _logBlobContainer;
            }
            internal set
            {
                _logBlobContainer = value;
            }
        }

        public static void LogQueuePoller(object state)
        {
            Trace.WriteLine("LogPoller has started -- seeing if there's anything in the queue for me!!");

            CloudQueueMessage msg = LogQueue.GetMessage();
            if (msg == null)
            {
                Trace.TraceInformation("LOG QUEUE nothing found - going back to sleep");
            }

            while (msg != null)
            {
                //do something
                string myMessage = msg.AsString;
                LogQueue.DeleteMessage(msg);
                Trace.TraceInformation("Got message {0}", myMessage);

                CloudBlockBlob theBlob = LogBlobContainer.GetBlockBlobReference(myMessage);
                BuzzyGo.Commands.Logging.LogCommand theLog;

                Util.DeserializeObjectFromBlob<BuzzyGo.Commands.Logging.LogCommand>(theBlob, out theLog);

                if (theLog != null)
                {
                    WriteLogToStorage(myMessage, theLog);
                }
                else
                {
                    Trace.TraceInformation("Could not deserialize message from queue id {0}", myMessage);
                }

                msg = LogQueue.GetMessage();
            }
        }

        private static void WriteLogToStorage(string myMessage, BuzzyGo.Commands.Logging.LogCommand theLog)
        {
            Trace.TraceInformation("Message text {0}, sent {1} from user {2} on queue id {3}",
                theLog.Message,
                theLog.LogTime.ToString(),
                theLog.UserID.ToString(),
                myMessage);

            BuzzyGo.Repository.Logging.LogEntry log = new BuzzyGo.Repository.Logging.LogEntry(theLog.UserID)
            {
                LogDate = theLog.LogTime,
                Message = theLog.Message,
                MessageType = theLog.MessageType
            };

            BuzzyGo.Repository.Logging.LogEntryDataSource data = new BuzzyGo.Repository.Logging.LogEntryDataSource();
            data.AddLogEntry(log);
        }

    }
}
