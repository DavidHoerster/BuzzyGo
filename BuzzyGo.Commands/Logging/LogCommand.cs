using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuzzyGo.Commands.Logging
{
    [Serializable]
    public class LogCommand
    {
        public Guid LogSourceID { get; set; }
        public String MessageType { get; set; }
        public String Message { get; set; }
        public Int64 UserID { get; set; }
        public DateTime LogTime { get; set; }
    }
}
