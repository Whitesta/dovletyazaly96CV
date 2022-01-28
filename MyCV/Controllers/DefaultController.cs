using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCV.Models.Entity;


namespace MyCV.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvProjectEntities1 db = new DbCvProjectEntities1();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.Experience.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Education()
        {
            var educations = db.Education.ToList();
            return PartialView(educations);
        }
        public PartialViewResult Skill()
        {
            var skills = db.Skills.ToList();
            return PartialView(skills);
        }
        public PartialViewResult Hobby()
        {
            var hobbies = db.Hobies.ToList();
            return PartialView(hobbies);
        }

        public PartialViewResult Certification()
        {
            var certifications = db.Certifications.ToList();
            return PartialView(certifications);
        }
        public PartialViewResult SocialMedya()
        {
            var socialMedya = db.SocialMedia.Where(x=>x.State==true).ToList();
            return PartialView(socialMedya);
        }
        [HttpGet]
        public PartialViewResult Communication()
        {
           
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Communication(Communication communication)
        {
            communication.Date = DateTime.Now.ToShortDateString();
            db.Communication.Add(communication);
            db.SaveChanges();
            return PartialView();
        }
    }
}