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
    public class EmployeeDA
    {
        //get ALL employees
        public static List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();

            string sql = "SELECT ID, EmployeeName, Address, Email, Phone FROM Employee";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //get employee with id
        public static Employee GetEmployee(int id)
        {
            string sql = "SELECT ID, EmployeeName, Address, Email, Phone FROM Employee WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql, par1);
            Employee result = null;

            while (reader.Read())
            {
                result = Create(reader);
            }
            reader.Close();
            return result;
        }

        //insert employee into DB
        public static void InsertEmployee(Employee e)
        {
            string sql = "INSERT INTO Employee VALUES(@ID, @EmployeeName, @Address, @Email, @Phone)";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", e.Id);
            DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@EmployeeName", e.EmployeeName);
            DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Address", e.Address);
            DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@Email", e.Email);
            DbParameter par5 = Database.AddParameter("ConnectionString-Customer", "@Phone", e.Phone);

            Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3, par4, par5);
        }

        //update employee in DB
        public static void EditEmployee(Employee e)
        {
            try
            {
                string sql = "UPDATE Employee SET EmployeeName=@EmployeeName, Address=@Address, Email=@Email, Phone=@Phone WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@EmployeeName", e.EmployeeName);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Address", e.Address);
                DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Email", e.Email);
                DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@Phone", e.Phone);
                DbParameter par5 = Database.AddParameter("ConnectionString-Customer", "@ID", e.Id);
                Database.ModifyData("ConnectionString-Customer", sql, par1, par2, par3, par4, par5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //delete employee from DB
        public static void DeleteEmployee(int id)
        {
            try
            {
                string sql = "DELETE FROM Employee WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
                Database.ModifyData("ConnectionString-Customer", sql, par1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //create employee
        private static Employee Create(IDataRecord record)
        {
            return new Employee()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                EmployeeName = record["EmployeeName"].ToString(),
                Address = record["Address"].ToString(),
                Email = record["Email"].ToString(),
                Phone = record["Phone"].ToString()
            };
        }
    }
}