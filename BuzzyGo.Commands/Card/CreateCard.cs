using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using BuzzyGo.Model.Card;

namespace BuzzyGo.Commands.Card
{
    [Serializable]
    [MapsToAggregateRootConstructor("BuzzyGo.Domain.Card, BuzzyGo.Domain")]
    public class CreateCard : CommandBase
    {
        public CreateCard()
        {
        }

        public Guid ID { get; set; }
        public Int64 CardID { get; set; }
        public String Name { get; set; }
        public String Purpose { get; set; }
        public CardBuzzWord[] Words { get; set; }
    }
}
