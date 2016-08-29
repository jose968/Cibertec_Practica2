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
    public class CustomerController : ChinnokBaseController<Customer>
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(_repository.PaginatedList((x => x.CustomerId), 1, 15));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Add(customer);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            _repository.Update(customer);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            //if (!ModelState.IsValid) return View(person);
            customer = _repository.GetById(x => x.CustomerId == customer.CustomerId);
            _repository.Delete(customer);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var customer = _repository.GetById(x => x.CustomerId == id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);

        }
    }
}