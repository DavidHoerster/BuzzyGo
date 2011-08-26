using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace BuzzyGo.Commands.Buzz
{
    [Serializable]
    [MapsToAggregateRootConstructor("BuzzyGo.Domain.Buzzword, BuzzyGo.Domain")]
    public class CreateNewBuzzword : CommandBase
    {
        public CreateNewBuzzword() { }

        public Guid ID { get; set; }
        public Int64 BuzzID { get; set; }
        public String BuzzwordName { get; set; }
        public String Category { get; set; }
    }
}
