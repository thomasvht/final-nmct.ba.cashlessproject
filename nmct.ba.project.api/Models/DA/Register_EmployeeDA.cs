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
    public class Register_EmployeeDA
    {
        //get ALL register_employees
        public static List<Register_Employee> GetRegister_Employees()
        {
            List<Register_Employee> list = new List<Register_Employee>();

            string sql = "SELECT RegisterID, EmployeeID, Van, Tot FROM Register_Employee";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //get register_employee with id
        public static List<Register_Employee> GetRegister_Employee(int id)
        {
            List<Register_Employee> list = new List<Register_Employee>();

            string sql = "SELECT RegisterID, EmployeeID, Van, Tot FROM Register_Employee WHERE RegisterID=@ID";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql, par1);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }
            reader.Close();
            return list;
        }

        //insert register_employee into DB
        public static void InsertRegisterEmployee(Register_Employee re)
        {
            string sql = "INSERT INTO Register_Employee VALUES(@RegisterID, @EmployeeID, @Van, @Tot)";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@RegisterID", re.RegisterID);
            DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@EmployeeID", re.EmployeeID);
            DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Van", DateTimeToUnixTimeStamp(re.Van));
            DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@Tot", DateTimeToUnixTimeStamp(re.Tot));

            Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3, par4);
        }

        //create register_employee
        private static Register_Employee Create(IDataRecord record)
        {
            return new Register_Employee()
            {
                RegisterID = Int32.Parse(record["RegisterID"].ToString()),
                RegisterName = RegisterDA.GetRegister(Int32.Parse(record["RegisterID"].ToString())).RegisterName,
                EmployeeID = Int32.Parse(record["EmployeeID"].ToString()),
                EmployeeName = EmployeeDA.GetEmployee(Int32.Parse(record["EmployeeID"].ToString())).EmployeeName,
                Van = UnixTimeStampToDateTime(Int32.Parse(record["Van"].ToString())),
                Tot = UnixTimeStampToDateTime(Int32.Parse(record["Tot"].ToString()))
            };
        }

        //UnixTimeStamp convert to DateTime
        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        //DateTime convert to UnixTimeStamp
        private static int DateTimeToUnixTimeStamp(DateTime t)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, t.Kind);
            var unixTimestamp = System.Convert.ToInt32((t - date).TotalSeconds);

            return unixTimestamp;
        }
    }
}