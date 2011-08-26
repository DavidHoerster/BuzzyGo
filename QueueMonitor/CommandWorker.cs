using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using Ncqrs.Commanding.ServiceModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Ncqrs.Commanding;

namespace BuzzyGo.QueueWorker
{
    public static class CommandWorker
    {
        private static CloudQueue _itemQueue;
        public static CloudQueue CommandQueue
        {
            get
            {
                return _itemQueue;
            }
            internal set
            {
                _itemQueue = value;
            }
        }

        private static CloudBlobContainer _itemBlobContainer;
        public static CloudBlobContainer CommandBlobContainer
        {
            get
            {
                return _itemBlobContainer;
            }
            internal set
            {
                _itemBlobContainer = value;
            }
        }

        public static void CommandQueuePoller(ICommandService service)
        {
            //Trace.WriteLine("LogPoller has started -- seeing if there's anything in the queue for me!!");

            CloudQueueMessage msg = CommandQueue.GetMessage();
            if (msg == null)
            {
                //Trace.TraceInformation("COMMAND QUEUE nothing found - going back to sleep");
            }

            while (msg != null)
            {
                //do something
                string myMessage = msg.AsString;
                CommandQueue.DeleteMessage(msg);
                Trace.TraceInformation("Got message {0}", myMessage);

                //split the ID from the type -- first item is ID, second is type
                string[] messageParts = myMessage.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                if (messageParts.Length!=2)
                {
                    Trace.TraceError("COMMAND QUEUE message improperly formed.  {0}", myMessage);
                    continue;
                }

                
                CloudBlockBlob theBlob = CommandBlobContainer.GetBlockBlobReference(messageParts[0]);
                Type commandType = Type.GetType(messageParts[1]);
                CommandBase theCommand = null;

                using (MemoryStream msBlob = new MemoryStream())
                {
                    byte[] logBytes = theBlob.DownloadByteArray();
                    msBlob.Write(logBytes, 0, logBytes.Length);
                    BinaryFormatter bf = new BinaryFormatter();
                    msBlob.Position = 0;
                    object theObject = bf.Deserialize(msBlob);
                    theCommand = Convert.ChangeType(theObject, commandType) as CommandBase;
                }

                if (theCommand != null)
                {
                    service.Execute(theCommand);
                }
                else
                {
                    Trace.TraceInformation("COMMAND BLOB Could not deserialize message from queue id {0}", myMessage);
                }

                msg = CommandQueue.GetMessage();
            }
        }

    }
}
