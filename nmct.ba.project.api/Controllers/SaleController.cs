using nmct.ba.cashlessproject.model.Klant;
using nmct.ba.project.api.Models;
using nmct.ba.project.api.Models.DA;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nmct.ba.project.api.Controllers
{
    public class SaleController : ApiController
    {
        public List<Sale> Get()
        {
            return SalesDA.GetSales();
        }

        public HttpResponseMessage Post(Sale s)
        {
            SalesDA.InsertSale(s);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}