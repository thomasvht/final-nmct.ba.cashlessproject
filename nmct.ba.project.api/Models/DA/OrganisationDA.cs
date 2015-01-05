using nmct.ba.cashlessproject.model;
using nmct.ba.project.api.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.project.api.Models.DA
{
    public class OrganisationDA
    {
        //get ALL organisations
        public static List<Organisation> GetOrganisations()
        {
            List<Organisation> list = new List<Organisation>();

            string sql = "SELECT ID, Login, Password, OrganisationName, Address, Email, Phone FROM Organisations";
            DbDataReader reader = Database.GetData("ConnectionString-IT", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //update organisation in DB
        public static void EditOrganisation(Organisation o)
        {
            try
            {
                string sql = "UPDATE Organisations SET Password=@Password WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@Password", o.Password);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@ID", o.Id);
                Database.ModifyData("ConnectionString-IT", sql, par1, par2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //create organisation
        private static Organisation Create(IDataRecord record)
        {
            return new Organisation()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                Login = record["Login"].ToString(),
                Password = record["Password"].ToString(),
                OrganisationName = record["OrganisationName"].ToString(),
                Address = record["Address"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString()
            };
        }
    }
}