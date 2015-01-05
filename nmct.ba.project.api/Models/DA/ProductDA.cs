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
    public class ProductDA
    {
        //get ALL products
        public static List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            string sql = "SELECT ID, ProductName, Price, Deleted FROM Products";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                Product p = Create(reader);
                if (p.Deleted == false)
                    list.Add(p);
            }

            reader.Close();
            return list;
        }

        //get ALL products WITH deleted
        public static List<Product> GetProductsWithDeleted()
        {
            List<Product> list = new List<Product>();

            string sql = "SELECT ID, ProductName, Price, Deleted FROM Products";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //get product with id
        public static Product GetProduct(int id)
        {
            string sql = "SELECT ID, ProductName, Price, Deleted FROM Products WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql, par1);
            Product result = null;

            while (reader.Read())
            {
                result = Create(reader);
            }
            reader.Close();
            return result;
        }

        //insert product into DB
        public static void InsertProduct(Product p)
        {
            List<Product> allProducts = GetProductsWithDeleted();
            Product product = null;

            foreach (Product pr in allProducts)
            {
                if (pr.ProductName == p.ProductName)
                    product = pr;
            }

            if (product == null)
            {
                string sql = "INSERT INTO Products VALUES(@ProductName, @Price, @Deleted)";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ProductName", p.ProductName);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Price", p.Price);
                DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Deleted", false);

                Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3);
            }
            else
            {
                string sql = "UPDATE Products SET Price=@Price, Deleted=@Deleted WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@Deleted", false);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Price", p.Price);
                DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@ID", product.Id);
                Database.ModifyData("ConnectionString-Customer", sql, par1, par2, par3);
            }
        }

        //update product in DB
        public static void EditProduct(Product p)
        {
            try
            {
                string sql = "UPDATE Products SET ProductName=@ProductName, Price=@Price WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@ProductName", p.ProductName);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Price", p.Price);
                DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@ID", p.Id);
                Database.ModifyData("ConnectionString-Customer", sql, par1, par2, par3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //delete product from DB
        public static void DeleteProduct(int id)
        {
            try
            {
                string sql = "UPDATE Products SET Deleted=@Deleted WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@Deleted", true);
                DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@ID", id);
                Database.ModifyData("ConnectionString-Customer", sql, par1, par2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //create product
        private static Product Create(IDataRecord record)
        {
            return new Product()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                ProductName = record["ProductName"].ToString(),
                Price = Double.Parse(record["Price"].ToString()),
                Deleted = Boolean.Parse(record["Deleted"].ToString())
            };
        }
    }
}