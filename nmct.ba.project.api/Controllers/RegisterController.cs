using nmct.ba.cashlessproject.model.Klant;
using nmct.ba.project.api.Models.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace nmct.ba.project.api.Controllers
{
    public class RegisterController : ApiController
    {
        public List<Register> Get()
        {
            return RegisterDA.GetRegisters();
        }

        public Register Get(int id)
        {
            return RegisterDA.GetRegister(id);
        }
    }
}