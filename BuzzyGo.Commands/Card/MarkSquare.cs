using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace BuzzyGo.Commands.Card
{
    [Serializable]
    [MapsToAggregateRootMethod("BuzzyGo.Domain.Card, BuzzyGo.Domain", "MarkSquare")]
    public class MarkSquare : CommandBase
    {
        public MarkSquare()
        {
        }

        [AggregateRootId()]
        public Guid ID { get; set; }
        public Int64 CardID { get; set; }
        public Guid SquareID { get; set; }
        public Boolean IsMarked { get; set; }
    }
}
