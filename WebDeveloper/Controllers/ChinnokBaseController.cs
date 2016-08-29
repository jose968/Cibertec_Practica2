using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.Filters;
using WebDeveloper.Repository;


namespace WebDeveloper.Controllers
{
    [AuditControl]
    [ExceptionControl]
    public class ChinnokBaseController<T> : Controller
             where T : class
    {
        // GET: Personnel/PersonBase
        protected IRepository<T> _repository;

        public ChinnokBaseController()
        {
            _repository = new BaseRepository<T>();
        }
    }
}