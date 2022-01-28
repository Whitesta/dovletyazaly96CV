using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<About> genericRepository = new GenericRepository<About>();

        [HttpGet]
        public ActionResult Index()
        {
            var values = genericRepository.GetAll();
            return View(values);
        }
        [HttpPost]
        public ActionResult Index(About about)
        {
            var values = genericRepository.Find(x => x.Id == 2);
            values.FirstName = about.FirstName;
            values.LastName = about.LastName;
            values.Address = about.Address;
            values.Mail = about.Mail;
            values.Explanation = about.Explanation;
            values.Foto = about.Foto;
            genericRepository.Update(values);

            return RedirectToAction("Index");
        }
    }
}