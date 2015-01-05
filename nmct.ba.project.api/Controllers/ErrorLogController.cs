using nmct.ba.cashlessproject.model.Klant;
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
    public class ErrorlogController : ApiController
    {
        public HttpResponseMessage Post(Errorlog e)
        {
            ErrorlogDA.InsertErrorlog(e);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}