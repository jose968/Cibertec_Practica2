using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Model;
using WebDeveloper.Repository;

namespace WebDeveloper.Controllers
{
    public class MediaTypeController : ChinnokBaseController<MediaType>
    {
        // GET: MediaType
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.MediaTypeId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(MediaType mediatype)
        {
            if (!ModelState.IsValid) return View(mediatype);
            _repository.Add(mediatype);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);
        }

        [HttpPost]
        public ActionResult Edit(MediaType mediatype)
        {
            if (!ModelState.IsValid) return View(mediatype);
            _repository.Update(mediatype);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);
        }

        [HttpPost]
        public ActionResult Delete(MediaType mediatype)
        {
            //if (!ModelState.IsValid) return View(person);
            mediatype = _repository.GetById(x => x.MediaTypeId == mediatype.MediaTypeId);
            _repository.Delete(mediatype);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var mediatype = _repository.GetById(x => x.MediaTypeId == id);
            if (mediatype == null) return RedirectToAction("Index");
            return View(mediatype);

        }
    }
}