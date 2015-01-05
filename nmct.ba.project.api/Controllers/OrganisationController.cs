using nmct.ba.cashlessproject.model;
using nmct.ba.project.api.Models.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace nmct.ba.project.api.Controllers
{
    public class OrganisationController : ApiController
    {
        public List<Organisation> Get()
        {
            return OrganisationDA.GetOrganisations();
        }

        public HttpResponseMessage Put(Organisation o)
        {
            OrganisationDA.EditOrganisation(o);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}