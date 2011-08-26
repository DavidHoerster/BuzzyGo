using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Domain;
using Ncqrs;
using BuzzyGo.Repository;

namespace BuzzyGo.Domain
{
    public class Buzzword : AggregateRootMappedByConvention
    {
        public Int64 BuzzID { get; private set; }
        public String BuzzwordName { get; private set; }
        public String Category { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

        public Buzzword() { }

        public Buzzword(Guid id,
            Int64 buzzID,
            String buzzwordName,
            String category)
        {
            var clock = NcqrsEnvironment.Get<IClock>();
            EventSourceId = id;

            if (DoesBuzzwordNotExistInRepository(buzzwordName, category))
            {
                ApplyEvent(new BuzzyGo.Events.Buzz.BuzzwordCreated()
                {
                    BuzzID = buzzID,
                    BuzzwordName = buzzwordName,
                    Category = category,
                    DateCreated = clock.UtcNow(),
                    TimesMarked = 0,
                    TimesUsed = 0
                });
            }
        }

        protected void OnBuzzwordCreated(BuzzyGo.Events.Buzz.BuzzwordCreated e)
        {
            BuzzID = e.BuzzID;
            BuzzwordName = e.BuzzwordName;
            Category = e.Category;
            CreateDate = e.DateCreated;
        }

        private Boolean DoesBuzzwordNotExistInRepository(String name, String category)
        {
            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                return ctx.Buzzwords
                    .Count(b => String.Compare(b.Name, name, true) == 0 && 
                                String.Compare(b.Category, category, true) == 0) == 0;
            }
        }

    }
}
