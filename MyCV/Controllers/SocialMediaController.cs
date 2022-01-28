using MyCV.Models.Entity;
using MyCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<SocialMedia> genericRepository = new GenericRepository<SocialMedia>();
        public ActionResult Index()
        {
            var list = genericRepository.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Add(SocialMedia socialMedia)
        {
            genericRepository.Add(socialMedia);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var values = genericRepository.Find(x => x.Id == id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var values= genericRepository.Find(x => x.Id == socialMedia.Id);
            values.Name = socialMedia.Name;
            values.Link = socialMedia.Link;
            values.Icon = socialMedia.Icon;
            values.State = true;
            genericRepository.Update(values);       
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var values = genericRepository.Find(x => x.Id == id);
            values.State = false;
            genericRepository.Update(values);
            return RedirectToAction("Index");
        }
    }
}