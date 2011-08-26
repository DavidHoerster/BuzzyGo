using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ncqrs;
using Ncqrs.Domain;
using BuzzyGo.Model.Card;

namespace BuzzyGo.Domain
{
    public class Card : AggregateRootMappedByConvention
    {
        public Guid ID                                  { get; protected set; }
        public Int64 CardID                             { get; protected set; }
        public String Name                              { get; protected set; }
        public String Purpose                           { get; protected set; }
        public DateTime DateCreated                     { get; protected set; }
        public BuzzyGo.Repository.CardSquare[] Squares  { get; protected set; }
        public Boolean IsActive                         { get; protected set; }

        public Card()
        {
        }

        public Card(Guid id,
                    Int64 cardID,
                    String name,
                    String purpose,
                    CardBuzzWord[] words)
        {
            EventSourceId = id;
            var clock = NcqrsEnvironment.Get<IClock>();

            ApplyEvent(new BuzzyGo.Events.Card.CardCreated()
            {
                CardID = cardID,
                DateCreated = clock.UtcNow(),
                Name = name,
                Purpose = purpose,
                Squares = CreateCardSquares(cardID, name, clock, words)
            });
        }

        public void MarkSquare(Int64 cardID,
            Guid squareID,
            Boolean isMarked)
        {
            var clock = NcqrsEnvironment.Get<IClock>();

            Boolean isCardAWinner = DetermineIfCardIsAWinner(cardID, squareID, isMarked);

            if (isCardAWinner)
            {
                //TODO: need to determine what this event will look like
                ApplyEvent(new BuzzyGo.Events.Card.CardMarkedAsWinner()
                {
                });
            }
            ApplyEvent(new BuzzyGo.Events.Card.SquareMarked()
            {
                CardID = cardID,
                SquareID = squareID,
                IsMarked = isMarked,
                CardUpdateDate = clock.UtcNow()
            });
        }

        public void DeleteCard(Int64 cardID)
        {
            var clock = NcqrsEnvironment.Get<IClock>();
            ApplyEvent(new BuzzyGo.Events.Card.CardDeleted()
                {
                    CardID = cardID,
                    UpdateDate = clock.UtcNow()
                });
        }

        protected void OnCardDeleted(BuzzyGo.Events.Card.CardDeleted e)
        {
            
        }

        protected void OnSquareMarked(BuzzyGo.Events.Card.SquareMarked e)
        {
            CardID = e.CardID;
        }

        protected void OnCardCreated(BuzzyGo.Events.Card.CardCreated e)
        {
            CardID = e.CardID;
            Name = e.Name;
            Purpose = e.Purpose;
            DateCreated = e.DateCreated;
            Squares = e.Squares;
        }

        protected void onCardMarkedAsWinner(BuzzyGo.Events.Card.CardMarkedAsWinner e)
        {
        }


        private BuzzyGo.Repository.CardSquare[] CreateCardSquares(Int64 cardID, String cardName, IClock clock, CardBuzzWord[] words)
        {
            CardBuzzWord[] wordsWithFree = new CardBuzzWord[25];
            for (int i = 0; i < 12; i++)
            {
                wordsWithFree[i] = words[i];
            }
            wordsWithFree[12] = new CardBuzzWord() { BuzzWordID = 0, BuzzWord = "FREE" };
            for (int i = 0; i < 12; i++)
            {
                wordsWithFree[13 + i] = words[12 + i];
            }

            List<BuzzyGo.Repository.CardSquare> squares = new List<Repository.CardSquare>();
            for (int i = 0; i < wordsWithFree.Length; i++)
            {
                squares.Add(new Repository.CardSquare()
                {
                    CardID = cardID,
                    IsMarked = (i==12), //if it's the 12th square, it's the free square
                    Name = cardName,
                    DateCreated = clock.UtcNow(),
                    DateUpdated = clock.UtcNow(),
                    SquareID = Guid.NewGuid(),
                    Value = wordsWithFree[i].BuzzWord,
                    BuzzID = wordsWithFree[i].BuzzWordID,
                    RowNum = ((int)(i / 5)) + 1,
                    ColNum = (i % 5) + 1
                });
            }

            return squares.ToArray();
        }

        private bool DetermineIfCardIsAWinner(long cardID, Guid squareID, bool isMarked)
        {
            return false;
        }

    }
}
