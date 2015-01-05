using nmct.ba.project.api.Models;
using nmct.ba.project.api.Models.DA;
using nmct.ba.cashlessproject.model.Klant;
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
    public class CustomerController : ApiController
    {
        public List<Customer> Get()
        {
            return CustomerDA.GetCustomers();
        }

        public Customer Get(int id)
        {
            return CustomerDA.GetCustomer(id);
        }

        public HttpResponseMessage Post(Customer c)
        {
            CustomerDA.InsertCustomer(c);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(Customer c)
        {
            CustomerDA.EditCustomer(c);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}