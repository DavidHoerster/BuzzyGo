using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BuzzyGo.Model.Card;
using Newtonsoft.Json;
using BuzzyGo.Repository;
using BuzzyGo.Web.Utility;

namespace BuzzyGo.Controllers
{
    public class CardController : BuzzyGoBaseController
    {
        [HttpGet]
        public ActionResult View(Int64 id)
        {
            ViewCardViewModel theModel = new ViewCardViewModel();
            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.ObjectTrackingEnabled = false;
                theModel.CardSquareInfo = ctx.CardSquares
                                            .Where(c => c.CardID == id)
                                            .OrderBy(c => c.RowNum)
                                            .ThenBy(c => c.ColNum)
                                            .ToList();
            }
            theModel.Name = theModel.CardSquareInfo[0].Name;
            theModel.CardID = theModel.CardSquareInfo[0].CardID;

            CloudHelper.LogMessage(0, String.Format("User VIEWED card {0} ({1})", theModel.Name, id.ToString()), "CARD");

            return View(theModel);
        }

        [HttpPost]
        public ActionResult SetSquareStatus(Int64 cardID, Guid squareID, Boolean isMarked)
        {
            BuzzyGo.Web.Utility.CloudHelper.EnqueueCommand(new BuzzyGo.Commands.Card.MarkSquare()
            {
                CardID = cardID,
                ID = BuzzyGo.Repository.UniqueID.UniqueIDUtility.GetGuidForSequenceID(cardID),
                IsMarked = isMarked,
                SquareID = squareID
            });

            CloudHelper.LogMessage(0, String.Format("User {0}marked a square for card id {1}", isMarked ? String.Empty : "un", cardID.ToString()), "CARD");

            return Json(new { isValid = true }, JsonRequestBehavior.DenyGet);
        }

        [HttpDelete]
        public ActionResult Delete(Int64 id)
        {
            BuzzyGo.Web.Utility.CloudHelper.EnqueueCommand(new BuzzyGo.Commands.Card.DeleteCard()
            {
                ID = BuzzyGo.Repository.UniqueID.UniqueIDUtility.GetGuidForSequenceID(id),
                CardID = id
            });

            CloudHelper.LogMessage(0, String.Format("User deleted card id {0}", id.ToString()), "CARD");

            return Json(new { isValid = true }, JsonRequestBehavior.DenyGet);
        }

        [HttpGet]
        public ActionResult List()
        {
            ListCardsViewModel theModel = new ListCardsViewModel();
            using (BuzzyGo.Repository.BuzzyCardsDataContext ctx = new Repository.BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.ObjectTrackingEnabled = false;
                theModel.Cards = ctx.Cards
                    .OrderByDescending(c => c.DateCreated)
                    .ToList();
            }

            CloudHelper.LogMessage(0, String.Format("User view a list of their cards.  There were {0} cards displayed", theModel.Cards.Count.ToString()), "CARD");

            return View(theModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var theModel = new CreateCardViewModel()
            {
                CardHeader = new Repository.Card(),
                CardBuzzWords = GetBuzzWordArrayForCard(24).ToList()
            };

            CloudHelper.LogMessage(0, "User is about to create a new card", "CARD");

            return View(theModel);
        }

        [HttpPost]
        public ActionResult Create(BuzzyGo.Model.Card.CreateCardViewModel theCard)
        {
            CardBuzzWord[] words = null;
            String wordList = ControllerContext.HttpContext.Request["wordlist"];
            if (!String.IsNullOrWhiteSpace(wordList))
            {
                words = JsonConvert.DeserializeObject<CardBuzzWord[]>(wordList);
            }

            BuzzyGo.Repository.UniqueID.UniqueID uid = GetNewUniqueID();

            BuzzyGo.Web.Utility.CloudHelper.EnqueueCommand(new BuzzyGo.Commands.Card.CreateCard()
            {
                CardID = uid.SequenceID,
                ID = uid.UniqueIdentifier,
                Name = theCard.CardHeader.Name,
                Purpose = theCard.CardHeader.Purpose,
                Words = words
            });

            CloudHelper.LogMessage(0, String.Format("User created a new card {0} (id {1})", theCard.CardHeader.Name, uid.SequenceID.ToString()), "CREATE CARD");

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult GetRandomBuzzWords(Int32 buzzwordsToRetrieve)
        {
            var randomSampleWords = GetBuzzWordArrayForCard(buzzwordsToRetrieve);

            CloudHelper.LogMessage(0, "User got a new set of random buzz words", "BUZZWORDS");

            return Json(randomSampleWords, JsonRequestBehavior.AllowGet);
        }

        private CardBuzzWord[] GetBuzzWordArrayForCard(Int32 buzzwordsToRetrieve)
        {
            using (BuzzyGo.Repository.BuzzyCardsDataContext ctx = new Repository.BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.ObjectTrackingEnabled = false;
                var allWordsAsList = ctx.Buzzwords
                                        .Select(w => w).ToList();
                var randomSampleWords = allWordsAsList
                                        .OrderBy(r => Guid.NewGuid())
                                        .Take(buzzwordsToRetrieve)
                                        .Select(r => new Model.Card.CardBuzzWord
                                        {
                                            BuzzWordID = r.BuzzID,
                                            BuzzWord = r.Name
                                        })
                                        .ToArray();
                return randomSampleWords;
            }
        }
    }
}
