using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BuzzyGo.Repository;
using BuzzyGo.Web.Utility;
using BuzzyGo.Model.Buzz;

namespace BuzzyGo.Controllers
{
    public class BuzzController : BuzzyGoBaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            BuzzyGo.Model.Buzz.CreateBuzzViewModel theModel = new Model.Buzz.CreateBuzzViewModel();

            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.ObjectTrackingEnabled = false;
                theModel.BuzzwordCategories = ctx.BuzzCategories.OrderBy(c => c.Name).ToList();
            }

            CloudHelper.LogMessage(0, "User about to create a new buzzword", "BUZZ");

            return View(theModel);
        }

        [HttpPost]
        public ActionResult Create(CreateBuzzViewModel model)
        {
            BuzzyGo.Repository.UniqueID.UniqueID uid = GetNewUniqueID();

            CloudHelper.EnqueueCommand(new BuzzyGo.Commands.Buzz.CreateNewBuzzword()
            {
                BuzzID = uid.SequenceID,
                BuzzwordName = model.TheBuzzword.Name,
                Category = model.TheBuzzword.Category,
                ID = uid.UniqueIdentifier
            });

            CloudHelper.LogMessage(0, String.Format("User created new buzzword {0} in category {1}", model.TheBuzzword.Name, model.TheBuzzword.Category), "BUZZ");

            return RedirectToAction("List", "Buzz");
        }

        [HttpGet]
        public ActionResult List()
        {
            ListBuzzwordsViewModel theModel = new ListBuzzwordsViewModel();
            using (BuzzyCardsDataContext ctx = new BuzzyCardsDataContext(BuzzyGo.Utilities.ConnectionStringHelper.GetCQRSConnectionString()))
            {
                ctx.ObjectTrackingEnabled = false;
                theModel.Buzzwords = ctx.Buzzwords
                                        .OrderBy(b => b.Category)
                                        .ThenBy(b => b.Name)
                                        .ToList();
            }

            return View(theModel.Buzzwords);
        }
    }
}
