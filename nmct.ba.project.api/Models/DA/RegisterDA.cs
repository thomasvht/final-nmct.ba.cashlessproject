using nmct.ba.cashlessproject.model.Klant;
using nmct.ba.project.api.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.project.api.Models.DA
{
    public class RegisterDA
    {
        //get ALL registers
        public static List<Register> GetRegisters()
        {
            List<Register> list = new List<Register>();

            string sql = "SELECT ID, RegisterName, Device FROM Registers";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //get register with id
        public static Register GetRegister(int id)
        {
            string sql = "SELECT ID, RegisterName, Device FROM Registers WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql, par1);
            Register result = null;

            while (reader.Read())
            {
                result = Create(reader);
            }
            reader.Close();
            return result;
        }

        //create register
        private static Register Create(IDataRecord record)
        {
            return new Register()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                RegisterName = record["RegisterName"].ToString(),
                Device = record["Device"].ToString()
            };
        }
    }
}