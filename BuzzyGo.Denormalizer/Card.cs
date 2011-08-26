using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuzzyGo.Events.Card;
using Ncqrs.Eventing.ServiceModel.Bus;
using BuzzyGo.Repository;

namespace BuzzyGo.Denormalizer
{
    public class Card : IEventHandler<CardCreated>,
                        IEventHandler<SquareMarked>,
                        IEventHandler<CardDeleted>
    {
        public void Handle(IPublishedEvent<CardCreated> evnt)
        {
            String connString = BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString();
            BuzzyGo.Repository.Card theCard = new Repository.Card()
            {
                CardID = evnt.Payload.CardID,
                DateCreated = evnt.Payload.DateCreated,
                ID = evnt.EventSourceId,
                Name = evnt.Payload.Name,
                Purpose= evnt.Payload.Purpose,
                IsActive = true,
                IsWinner = false
            };

            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(connString))
            {
                var buzzwordsToUpdate = ctx.Buzzwords
                                            .Where(b => evnt.Payload.Squares
                                                            .Select(i => i.BuzzID)
                                                            .Contains(b.BuzzID)
                                                  );

                foreach (var buzzword in buzzwordsToUpdate)
                {
                    buzzword.TimesUsed += 1;
                }

                ctx.Cards.InsertOnSubmit(theCard);
                ctx.CardSquares.InsertAllOnSubmit(evnt.Payload.Squares);
                ctx.SubmitChanges();
            }
        }

        public void Handle(IPublishedEvent<SquareMarked> evnt)
        {
            String connString = BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString();
            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(connString))
            {
                var theCard = ctx.Cards.SingleOrDefault(c => c.CardID == evnt.Payload.CardID);
                if (theCard != null)
                {
                    //TODO: something here around stats on the card about how many squares are marked
                }

                var theSquare = ctx.CardSquares.SingleOrDefault(c => c.SquareID == evnt.Payload.SquareID);
                if (theSquare != null)
                {
                    theSquare.IsMarked = evnt.Payload.IsMarked;
                    theSquare.DateUpdated = evnt.Payload.CardUpdateDate;
                }

                var theBuzzWord = ctx.Buzzwords.SingleOrDefault(b => b.BuzzID == theSquare.BuzzID);
                if (theBuzzWord != null)
                {
                    theBuzzWord.TimesMarked += evnt.Payload.IsMarked ? 1 : -1;
                }

                ctx.SubmitChanges();
            }
        }

        public void Handle(IPublishedEvent<CardDeleted> evnt)
        {
            String connString = BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString();
            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(connString))
            {
                var theCard = ctx.Cards.SingleOrDefault(c => c.ID == evnt.EventSourceId);
                ctx.Cards.DeleteOnSubmit(theCard);

                var cardSquares = ctx.CardSquares.Where(s => s.CardID == evnt.Payload.CardID);
                if (cardSquares != null && cardSquares.Count() > 0)
                {
                    ctx.CardSquares.DeleteAllOnSubmit(cardSquares);

                    var buzzIDs = cardSquares.Select(s => s.BuzzID).ToArray();
                    var buzzWords = ctx.Buzzwords.Where(b => buzzIDs.Select(i => i).Contains(b.BuzzID));

                    foreach (var buzz in buzzWords)
                    {
                        if (buzz.TimesMarked > 0)
                        {
                            buzz.TimesMarked--;
                        }
                        if (buzz.TimesUsed > 0)
                        {
                            buzz.TimesUsed--;
                        }
                    }
                }
                
                ctx.SubmitChanges();
            }
        }
    }
}
