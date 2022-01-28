using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository educationRepository = new EducationRepository();
        [Authorize]
        public ActionResult Index()
        {
            var list = educationRepository.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            educationRepository.Add(education);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEducation(int id)
        {
            var values = educationRepository.Find(x => x.Id == id);
            educationRepository.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var result = educationRepository.Find(x => x.Id == id);
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var values = educationRepository.Find(x => x.Id == education.Id);
            values.Id = education.Id;
            values.Header = education.Header;
            values.LowerTitle1 = education.LowerTitle1;
            values.LowerTitle2 = education.LowerTitle2;
            values.Date = education.Date;
            educationRepository.Update(values);
            return RedirectToAction("Index");
        }
    }
}