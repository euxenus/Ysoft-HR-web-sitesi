using Proje.Models;
using Proje.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proje.Controllers
{
    public class ProjectController : BaseController
    {
        Proje.Models.SurveyEntities db = new Models.SurveyEntities();
       
        public ActionResult Index()
        {
            var model = db.Project.ToList();
            return View(model);
        }

        public ActionResult Create(Project project)
        {
            if (project.Project1 != null)
            {
                project.CreateDate = DateTime.Now;
                project.CreateBy = NameSurname;
                db.Project.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }




        }
    }
}