using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace nmct.ba.project.api.Controllers
{
    public class KassaController : Controller
    {
        // GET: Kassa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Overzicht()
        {
            return View();
        }

        public ActionResult Toevoegen()
        {
            return View();
        }

        public ActionResult Link()
        {
            return View();
        }
    }
    }
