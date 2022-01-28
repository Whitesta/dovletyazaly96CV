using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class CertificationsController : Controller
    {
        // GET: Certifications
        GenericRepository<Certifications> genericRepository = new GenericRepository<Certifications>();
        public ActionResult Index()
        {
            var list = genericRepository.GetAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult UpdateCertification(int id)
        {
            var result = genericRepository.Find(x => x.Id == id);
            ViewBag.d = id;
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateCertification(Certifications certifications)
        {
            var values = genericRepository.Find(x => x.Id == certifications.Id);
            values.Title = certifications.Title;
            values.Date = certifications.Date;
            genericRepository.Update(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCertification()
        {  
            return View();
        }
        [HttpPost]
        public ActionResult AddCertification(Certifications certifications)
        {
            genericRepository.Add(certifications);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertification(int id)
        {
            var values = genericRepository.Find(x => x.Id == id);
            genericRepository.Delete(values);
            return RedirectToAction("Index");
        }
    }
}