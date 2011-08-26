using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace BuzzyGo.Events.Card
{
    [Serializable]
    public class CardDeleted : EventSource
    {
        public Guid ID { get { return EventSourceId; } }
        public Int64 CardID { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
