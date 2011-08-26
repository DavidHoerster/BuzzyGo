using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BuzzyGo.Repository.UniqueID;

namespace BuzzyGo.Controllers
{
    public abstract class BuzzyGoBaseController : Controller
    {
        public UniqueID GetNewUniqueID() { return Repository.UniqueID.UniqueIDUtility.GenerateNewUniqueID(); }

    }
}
