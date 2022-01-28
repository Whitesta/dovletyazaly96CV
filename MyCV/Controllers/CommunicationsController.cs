using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class CommunicationsController : Controller
    {
        // GET: Communications
        GenericRepository<Communication> genericRepository = new GenericRepository<Communication>();
        public ActionResult Index()
        {
            var list = genericRepository.GetAll();
            return View(list);
        }
    }
}