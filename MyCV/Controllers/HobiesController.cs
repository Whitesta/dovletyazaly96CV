using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class HobiesController : Controller
    {
        // GET: Hobies
        GenericRepository<Hobies> genericRepository = new GenericRepository<Hobies>();

        public ActionResult Index()
        {
            var result = genericRepository.GetAll();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddHobby()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHobby(Hobies hobies)
        {
            genericRepository.Add(hobies);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHobby(int id)
        {
            var values = genericRepository.Find(x => x.Id == id);
            return View(values);
        }
        
        [HttpPost]
        public ActionResult UpdateHobby(Hobies hobies)
        {
            var values = genericRepository.Find(x => x.Id == hobies.Id);
            values.Header = hobies.Header;
            values.Title = hobies.Title;
            genericRepository.Update(values);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHobby(int id)
        {
            var values = genericRepository.Find(x => x.Id == id);
            genericRepository.Delete(values);
            return RedirectToAction("Index");
        }
    }
}