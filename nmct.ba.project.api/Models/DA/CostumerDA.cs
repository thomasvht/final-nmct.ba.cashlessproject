using nmct.ba.project.api.Helper;
using nmct.ba.cashlessproject.model.Klant;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.project.api.Models.DA
{
    public class CustomerDA
    {
        //get ALL customers
        public static List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            string sql = "SELECT ID, CustomerName, Address, Picture, Balance FROM Customers";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //get customer with id
        public static Customer GetCustomer(int id)
        {
            string sql = "SELECT ID, CustomerName, Address, Picture, Balance FROM Customers WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql, par1);
            Customer result = null;

            while (reader.Read())
            {
                result = Create(reader);
            }
            reader.Close();
            return result;
        }

        //insert customer to DB
        public static void InsertCustomer(Customer c)
        {
            string sql = "INSERT INTO Customers VALUES(@CustomerName, @Address, @Picture, @Balance)";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@CustomerName", c.CustomerName);
            DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Address", c.Address);
            DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Picture", c.Picture);
            DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@Balance", c.Balance);

            Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3, par4);
        }

        //update customer in DB
        public static void EditCustomer(Customer c)
        {
            try
            {
                string sql = "UPDATE Customers SET Balance=@Balance WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@Balance", c.Balance);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@ID", c.Id);
                Database.ModifyData("ConnectionString-Customer", sql, par1, par2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //create customer
        private static Customer Create(IDataRecord record)
        {
            byte[] bytes = null;
            if (record["Picture"] != null && record["Picture"] != DBNull.Value && record["Picture"] is byte[])
            {
                bytes = (byte[])record["Picture"];
            }

            return new Customer()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                CustomerName = record["CustomerName"].ToString(),
                Address = record["Address"].ToString(),
                Picture = bytes,
                Balance = Double.Parse(record["Balance"].ToString())
            };
        }
    }
}