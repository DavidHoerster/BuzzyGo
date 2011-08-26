using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace BuzzyGo.Events.Card
{
    [Serializable]
    public class SquareMarked : EventSource
    {
        public SquareMarked() { }

        public Guid ID { get { return EventSourceId; } }
        public Int64 CardID { get; set; }
        public Guid SquareID { get; set; }
        public Boolean IsMarked { get; set; }
        public DateTime CardUpdateDate { get; set; }
    }
}
