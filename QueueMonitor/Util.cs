using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BuzzyGo.QueueWorker
{
    internal static class Util
    {
        internal static void DeserializeObjectFromBlob<T>(CloudBlockBlob theBlob, out T theObject) 
            where T:class
        {
            using (MemoryStream msBlob = new MemoryStream())
            {
                byte[] logBytes = theBlob.DownloadByteArray();
                msBlob.Write(logBytes, 0, logBytes.Length);
                BinaryFormatter bf = new BinaryFormatter();
                msBlob.Position = 0;
                theObject = bf.Deserialize(msBlob) as T;
            }
        }

    }
}
