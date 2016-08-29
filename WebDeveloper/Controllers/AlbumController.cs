﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Model;
using WebDeveloper.Repository;
namespace WebDeveloper.Controllers
{
    public class AlbumController : ChinnokBaseController<Album>
    {
        // GET: Album
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.AlbumId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (!ModelState.IsValid) return View(album);
            _repository.Add(album);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (!ModelState.IsValid) return View(album);
            _repository.Update(album);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);
        }

        [HttpPost]
        public ActionResult Delete(Album album)
        {
            //if (!ModelState.IsValid) return View(person);
            album = _repository.GetById(x => x.AlbumId == album.AlbumId);
            _repository.Delete(album);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var album = _repository.GetById(x => x.AlbumId == id);
            if (album == null) return RedirectToAction("Index");
            return View(album);

        }

    }
}