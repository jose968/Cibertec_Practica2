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
    public class ArtistController : ChinnokBaseController<Artist>
    {
        // GET: Artist
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.ArtistId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Add(artist);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            if (!ModelState.IsValid) return View(artist);
            _repository.Update(artist);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            //if (!ModelState.IsValid) return View(person);
            artist = _repository.GetById(x => x.ArtistId == artist.ArtistId);
            _repository.Delete(artist);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var artist = _repository.GetById(x => x.ArtistId == id);
            if (artist == null) return RedirectToAction("Index");
            return View(artist);

        }
    }
}