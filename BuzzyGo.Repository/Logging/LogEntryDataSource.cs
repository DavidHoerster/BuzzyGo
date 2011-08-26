using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace BuzzyGo.Repository.Logging
{
    public class LogEntryDataSource
    {
        private static CloudStorageAccount storageAccount;
        private LogDataContext context;

        static LogEntryDataSource()
        {
            storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
            CloudTableClient.CreateTablesFromModel(
                typeof(LogDataContext),
                storageAccount.TableEndpoint.AbsoluteUri,
                storageAccount.Credentials);
        }

        public LogEntryDataSource()
        {
            this.context = new LogDataContext(storageAccount.TableEndpoint.AbsoluteUri, storageAccount.Credentials);
            this.context.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
        }

        public void AddLogEntry(LogEntry entry)
        {
            this.context.AddObject("LogEntry", entry);
            this.context.SaveChanges();
        }

        public IEnumerable<LogEntry> GetEntries()
        {
            var results = from e in this.context.LogEntry
                          orderby e.PartitionKey, e.RowKey
                          select e;
            return results;
        }

        public IEnumerable<LogEntry> GetEntriesByUserID(string userID)
        {
            var results = from e in this.context.LogEntry
                          where e.PartitionKey == userID
                          orderby e.RowKey
                          select e;
            return results;
        }
    }
}
