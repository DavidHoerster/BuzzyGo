using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace BuzzyGo.Events.Buzz
{
    [Serializable]
    public class BuzzwordCreated : SourcedEvent
    {
        public Guid ID { get { return EventSourceId; } }
        public Int64 BuzzID { get; set; }
        public String BuzzwordName { get; set; }
        public String Category { get; set; }
        public DateTime DateCreated { get; set; }
        public Int32 TimesUsed { get; set; }
        public Int32 TimesMarked { get; set; }
    }
}
