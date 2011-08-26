using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.ServiceModel.Bus;
using BuzzyGo.Events.Buzz;
using BuzzyGo.Repository;

namespace BuzzyGo.Denormalizer
{
    public class Buzz : IEventHandler<BuzzwordCreated>
    {
        public void Handle(IPublishedEvent<BuzzwordCreated> evnt)
        {
            Buzzword theBuzz = new Buzzword()
            {
                BuzzID = evnt.Payload.BuzzID,
                Category = evnt.Payload.Category,
                DateCreated = evnt.Payload.DateCreated,
                ID = evnt.EventSourceId,
                Name = evnt.Payload.BuzzwordName,
                TimesMarked = 0,
                TimesUsed = 0
            };

            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.Buzzwords.InsertOnSubmit(theBuzz);
                ctx.SubmitChanges();
            }
        }
    }
}
