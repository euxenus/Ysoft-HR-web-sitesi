using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
    public class LoginController : Controller
    {
        Proje.Models.SurveyEntities db = new Models.SurveyEntities();
        public ActionResult SignIn(string UserName, string Password)
        {
            if (UserName == null)
            {
                return View();
            }
            else
            {
                var person = db.Person.FirstOrDefault(m => m.UserName == UserName && m.Password == Password);
                if (person != null)
                {
                    Session["UserName"] = person.UserName;
                    Session["NameSurname"] = person.NameSurname;
                    return RedirectToAction("Index","Person");
                }
                else
                {
                    ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();

                }
            }
            
        }
    }
}