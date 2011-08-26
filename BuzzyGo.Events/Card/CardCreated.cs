using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace BuzzyGo.Events.Card
{
    [Serializable]
    public class CardCreated : EventSource
    {
        public CardCreated() { }

        public Guid ID { get { return EventSourceId; } }
        public Int64 CardID { get; set; }
        public String Name { get; set; }
        public String Purpose { get; set; }
        public DateTime DateCreated { get; set; }
        public BuzzyGo.Repository.CardSquare[] Squares { get; set; }
    }
}
