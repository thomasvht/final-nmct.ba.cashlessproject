using nmct.ba.cashlessproject.model.Klant;
using nmct.ba.project.api.Models.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace nmct.ba.project.api.Controllers
{
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            return ProductDA.GetProducts();
        }

        public Product Get(int id)
        {
            return ProductDA.GetProduct(id);
        }

        public HttpResponseMessage Post(Product p)
        {
            ProductDA.InsertProduct(p);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(Product p)
        {
            ProductDA.EditProduct(p);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            ProductDA.DeleteProduct(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}