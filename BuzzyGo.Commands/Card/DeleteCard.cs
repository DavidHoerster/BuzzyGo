using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Ncqrs.Commanding;

namespace BuzzyGo.Commands.Card
{
    [Serializable]
    [MapsToAggregateRootMethod("BuzzyGo.Domain.Card, BuzzyGo.Domain", "DeleteCard")]
    public class DeleteCard : CommandBase
    {
        public DeleteCard()
        {
        }

        [AggregateRootId()]
        public Guid ID { get; set; }
        public Int64 CardID { get; set; }
    }
}
