using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> genericRepository = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var list = genericRepository.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            genericRepository.Add(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = genericRepository.Find(x => x.Id == id);
            genericRepository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = genericRepository.Find(x => x.Id == id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var values = genericRepository.Find(x => x.Id == admin.Id);
            values.Id = admin.Id;
            values.UserName = admin.UserName;
            values.Password = admin.Password;
            genericRepository.Update(values);
            return RedirectToAction("Index");
        }
    }
}