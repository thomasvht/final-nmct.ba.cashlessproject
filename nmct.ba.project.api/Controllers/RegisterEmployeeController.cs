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
    public class RegisterEmployeeController : ApiController
    {
        public List<Register_Employee> Get()
        {
            return Register_EmployeeDA.GetRegister_Employees();
        }

        public List<Register_Employee> Get(int id)
        {
            return Register_EmployeeDA.GetRegister_Employee(id);
        }

        public HttpResponseMessage Post(Register_Employee re)
        {
            Register_EmployeeDA.InsertRegisterEmployee(re);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}