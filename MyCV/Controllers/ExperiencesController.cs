using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class ExperiencesController : Controller
    {
        // GET: Skills
        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.GetAll(); 
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Experience experience)
        {
            experienceRepository.Add(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Experience experience = experienceRepository.Find(x => x.Id == id);
            experienceRepository.Delete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            Experience experience = experienceRepository.Find(x => x.Id == id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult GetExperience(Experience experience)
        {
            Experience e = experienceRepository.Find(x => x.Id == experience.Id);
            e.Id = experience.Id;
            e.Header = experience.Header;
            e.LowerTitle = experience.LowerTitle;
            e.Explanation = experience.Explanation;
            e.Date = experience.Date;
            experienceRepository.Update(e);
            return RedirectToAction("Index");
        }
    }
}