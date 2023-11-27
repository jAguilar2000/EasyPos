using EasyPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyPos.Controllers
{
    public class OrdenesCompraController : Controller
    {
        // GET: OrdenesCompra
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}