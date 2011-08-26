using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing;

namespace BuzzyGo.Events.Card
{
    [Serializable]
    public class CardMarkedAsWinner : SourcedEvent
    {
    }
}
