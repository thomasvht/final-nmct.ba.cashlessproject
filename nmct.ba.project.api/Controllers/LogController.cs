﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nmct.ba.project.api.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Overzicht()
        {
            return View();
        }

        public ActionResult Aanmaken()
        {
            return View();
        }

        [HttpGet]
        public FileResult Download(int logId)
        {
            return null;
            //return File(System.IO.File.ReadAllBytes(path), System.Net.Mime.MediaTypeNames.Application.Octet, RegistersIT.Id);
        }
    }
}