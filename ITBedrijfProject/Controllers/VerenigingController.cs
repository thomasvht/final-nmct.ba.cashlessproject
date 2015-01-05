﻿using ITBedrijfProject.DataAcces;
using ITBedrijfProject.Models;
using ITBedrijfProject.PresentationModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITBedrijfProject.Controllers
{
    public class VerenigingController : Controller
    {
        // GET: Vereniging
        public ActionResult Index()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            List<Organisation> organisations = DAOrganisation.GetOrganisations();

            ViewBag.Organisations = organisations;

            return View();
        }

        [HttpGet]
        public ActionResult NewOrganisation()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            //var context = new ApplicationDbContext();
            //ViewBag.Users = context.Users;
            return View();
        }

        [HttpPost]
        public ActionResult NewOrganisation(PMOrganisation organisation)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            if (ModelState.IsValid)
            {
                if (DAOrganisation.InsertOrganisation(organisation) < 0) return View(organisation);
                return RedirectToAction("Index");
            }
            return View(organisation);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Organisation organisation = DAOrganisation.GetOrganisationById(id);
            ViewBag.Organisation = organisation;
            ViewBag.Id = id;
            return View(organisation);
        }

        [HttpPost]
        public ActionResult Details()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            PMOrganisation organisation = DAOrganisation.GetOrganisationById(id);
            ViewBag.Organisation = organisation;
            ViewBag.Id = id;
            return View(organisation);
        }

        [HttpPost]
        public ActionResult Edit(PMOrganisation organisation, int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            if (ModelState.IsValid)
            {
                DAOrganisation.UpdateOrganisation(id, organisation);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit", new { organisation = organisation, id = id });


        }

        [HttpGet]
        public ActionResult Register(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            ViewBag.Register = DAOrganisationRegister.GetOrganisationRegisterById(id);
            ViewBag.Organisation = DAOrganisation.GetOrganisationById(id);
            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            return RedirectToAction("Index");


        }

        [HttpGet]
        public ActionResult NewRegister(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            PMOrganisationRegister organisationRegister = new PMOrganisationRegister();
            organisationRegister.NewRegister = new MultiSelectList(DARegister.GetRegisters(), "Id", "RegisterName", "Device");
            organisationRegister.OrganisationID = id;
            ViewBag.Organisation = DAOrganisation.GetOrganisationById(id);
            return View(organisationRegister);
        }

        [HttpPost]
        public ActionResult NewRegister(int organisationID, int registerID, DateTime FromDate, DateTime FromTime, DateTime UntilDate, DateTime UntilTime)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            if (FromDate >= UntilDate) return RedirectToAction("Register", new { id = organisationID });
            OrganisationRegister organisationRegister = new OrganisationRegister();
            organisationRegister.OrganisationID = organisationID;
            organisationRegister.RegisterID = registerID;
            organisationRegister.FromDate = new DateTime(FromDate.Year, FromDate.Month, FromDate.Day, FromTime.Hour, FromTime.Minute, 0);
            organisationRegister.UntilDate = new DateTime(UntilDate.Year, UntilDate.Month, UntilDate.Day, UntilTime.Hour, UntilTime.Minute, 0);

            DAOrganisationRegister.InsertOrganisationRegister(organisationRegister);
            return RedirectToAction("Register", new { id = organisationID });
        }

        [HttpGet]
        public ActionResult EditRegister(int organisationID, int registerID)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            PMOrganisationRegister organisationRegister = new PMOrganisationRegister();
            organisationRegister.NewOrganisation = new MultiSelectList(DAOrganisation.GetOrganisations(), "Id", "OrganisationName");
            OrganisationRegister or = DAOrganisationRegister.GetOrganisationRegisterByIds(organisationID, registerID);
            organisationRegister.Device = or.Device;
            organisationRegister.FromDate = or.FromDate;
            organisationRegister.Login = or.Login;
            organisationRegister.OrganisationID = or.OrganisationID;
            organisationRegister.OrganisationName = or.OrganisationName;
            organisationRegister.RegisterID = or.RegisterID;
            organisationRegister.RegisterName = or.RegisterName;
            organisationRegister.UntilDate = or.UntilDate;

            ViewBag.Organisation = DAOrganisation.GetOrganisationById(organisationID);
            ViewBag.oldId = organisationID;
            return View(organisationRegister);
        }

        [HttpPost]
        public ActionResult EditRegister(int oldOrganisationID, int organisationID, DateTime fromDate, DateTime untilDate, int registerID)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            OrganisationRegister organisationRegister = DAOrganisationRegister.GetOrganisationRegisterByIds(organisationID, registerID);
            organisationRegister.FromDate = fromDate;
            organisationRegister.OrganisationID = organisationID;
            organisationRegister.RegisterID = registerID;
            organisationRegister.UntilDate = untilDate;
            DAOrganisationRegister.UpdateOrganisationRegister(oldOrganisationID, organisationRegister);
            return RedirectToAction("Register", new { id = oldOrganisationID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (User.Identity.Name == "") return RedirectToAction("ErrorLogin", "Home");
            Organisation organisation = DAOrganisation.GetOrganisationById(id);
            return View(organisation);
        }

        //Dit wordt uitgevoerd wanneer er op de deleteknop gedrukt wordt 
        [HttpPost]
        public ActionResult DeleteItem(int Id)
        {

            DAOrganisation.DeleteOrganisation(Id);

            return RedirectToAction("Index");


        }
    
    }
}