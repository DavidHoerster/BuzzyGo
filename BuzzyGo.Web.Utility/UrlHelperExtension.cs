using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Web.Mvc
{
    public static class UrlHelperExtension
    {
        #region Route Helpers

        public static String Home(this UrlHelper helper)
        {
            return helper.Action("Index", new { controller = "Home" });
        }

        public static String CreateCard(this UrlHelper helper)
        {
            return helper.Action("Create", new { controller = "Card" });
        }

        public static String ListCards(this UrlHelper helper)
        {
            return helper.Action("List", new { controller = "Card" });
        }

        public static String DeleteCard(this UrlHelper helper, Int64 id)
        {
            return helper.Action("Delete", new { controller = "Card", id = id });
        }

        public static String DeleteConfirm(this UrlHelper helper)
        {
            return helper.Action("DeleteConfirm", new { controller = "Card" });
        }

        public static String CreateBuzz(this UrlHelper helper)
        {
            return helper.Action("Create", new { controller = "Buzz" });
        }

        public static String ListBuzzwords(this UrlHelper helper)
        {
            return helper.Action("List", new { controller = "Buzz" });
        }

        #endregion

        #region Location Helpers

        public static string Images(this UrlHelper helper, String fileName)
        {
            return helper.Content("~/Content/Images/" + fileName);
        }

        public static string Styles(this UrlHelper helper, String fileName)
        {
            return helper.Content("~/Content/Styles/" + fileName);
        }

        public static string Scripts(this UrlHelper helper, String fileName)
        {
            return helper.Content("~/Content/Scripts/" + fileName);
        }
        #endregion

    }
}
