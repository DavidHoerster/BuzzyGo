using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BuzzyGo.Web.Utility;

namespace BuzzyGo.Controllers
{
    public class HomeController : BuzzyGoBaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            CloudHelper.LogMessage(0, "ANONYMOUS user visited home page", "HOME");

            return View();
        }
    }
}
