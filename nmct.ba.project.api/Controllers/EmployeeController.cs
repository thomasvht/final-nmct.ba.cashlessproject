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
    public class EmployeeController : ApiController
    {
        public List<Employee> Get()
        {
            return EmployeeDA.GetEmployees();
        }

        public Employee Get(int id)
        {
            return EmployeeDA.GetEmployee(id);
        }

        public HttpResponseMessage Post(Employee e)
        {
            EmployeeDA.InsertEmployee(e);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Put(Employee e)
        {
            EmployeeDA.EditEmployee(e);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            EmployeeDA.DeleteEmployee(id);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}