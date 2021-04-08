using System;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace AlutechShopDiploma.Controllers
{
    public class LocalesController : Controller
    {        
        public ActionResult Index(string languageAbbreviation)
        {
            if(languageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageAbbreviation);
            }
            /*if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());*/

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = languageAbbreviation;
            Response.Cookies.Add(cookie);

            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.ToString());

            return Content("Message");
        }

    }
}