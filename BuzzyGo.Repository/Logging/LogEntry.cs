using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Services.Common;
using Microsoft.WindowsAzure.StorageClient;

namespace BuzzyGo.Repository.Logging
{
    public class LogEntry : TableServiceEntity
    {
        public LogEntry(Int64 userID)
        {
            PartitionKey = userID.ToString();
            // Row key allows sorting, so we make sure the rows come back in time order.
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        public LogEntry()
        {
            PartitionKey = "ANONYMOUS";
            // Row key allows sorting, so we make sure the rows come back in time order.
            RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
        }

        public String MessageType { get; set; }
        public String Message { get; set; }
        public DateTime LogDate { get; set; }
    }

}
