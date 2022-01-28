using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository<Skills> genericRepository = new GenericRepository<Skills>();
        [Authorize]
        public ActionResult Index()
        {
            var values = genericRepository.GetAll();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skills skills)
        {
            genericRepository.Add(skills);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            var result = genericRepository.Find(x => x.Id == id);
            genericRepository.Delete(result);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var result= genericRepository.Find(x => x.Id == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateSkill( Skills skills)
        {
            var values = genericRepository.Find(x => x.Id == skills.Id);
            values.Skill = skills.Skill;
            values.Progress = skills.Progress;
            genericRepository.Update(values);
            return RedirectToAction("Index");
        }
    }
}