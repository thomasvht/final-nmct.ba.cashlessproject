using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using ITBedrijfProject.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijfProject.Controllers
{
    public class KassaController : Controller
    {
        // GET: Kassa
        public ActionResult Index()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            List<Register> registers = DARegister.GetRegisters();
            ViewBag.Registers = registers;
            return View();
        }

        [HttpGet]
        public ActionResult NewRegister()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            //var context = new ApplicationDbContext();
            //ViewBag.Users = context.Users;
            return View();
        }

        [HttpPost]
        public ActionResult NewRegister(PMRegister register)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            if (ModelState.IsValid)
            {
                if (register.PurchaseDate >= register.ExpiresDate) return View(register);
                DARegister.InsertRegister(register);
                return RedirectToAction("Index");
            }
            return View(register);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Register register = DARegister.GetRegisterById(id);
            ViewBag.Register = register;
            ViewBag.Id = id;
            return View(register);
        }

        [HttpPost]
        public ActionResult Edit(Register register, int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            if (ModelState.IsValid)
            {
                DARegister.UpdateRegister(id, register);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { register = register, id = id });


        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Register register = DARegister.GetRegisterById(id);
            ViewBag.Register = register;
            ViewBag.Id = id;
            return View(register);
        }

        [HttpPost]
        public ActionResult Details()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logs(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Register register = DARegister.GetRegisterById(id);
            ViewBag.Register = register;

           List<Errorlog> log = DAErrorLog.GetLogsById(id);
             ViewBag.Log = log;
             ViewBag.Id = id;
             return View();
        }

        [HttpPost]
        public ActionResult Logs()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Register register = DARegister.GetRegisterById(id);
            return View(register);
        }

        //Dit wordt uitgevoerd wanneer er op de deleteknop gedrukt wordt 
        [HttpPost]
        public ActionResult DeleteItem(int Id)
        {
            DARegister.DeleteRegister(Id);

            return RedirectToAction("Index");


        }
    
    }
}