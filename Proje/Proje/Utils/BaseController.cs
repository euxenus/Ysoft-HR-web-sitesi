using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Utils
{
    public class BaseController : Controller

    {
        Proje.Models.SurveyEntities db = new Models.SurveyEntities();
        public string UserName { get; set; }
        public string NameSurname { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UserName"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/SignIn");
            }
            else
            {
                UserName = Session["UserName"].ToString();
                NameSurname = Session["NameSurname"].ToString();

            }
            base.OnActionExecuting(filterContext);
        }
    }
}