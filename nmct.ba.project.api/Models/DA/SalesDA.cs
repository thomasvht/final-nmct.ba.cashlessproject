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
    public class SaleDA
    {
        //get ALL sales
        public static List<Sale> GetSales()
        {
            List<Sale> list = new List<Sale>();

            string sql = "SELECT ID, Timestamp, CustomerID, RegisterID, ProductID, Amount, Price, TotalPrice FROM Sales";
            DbDataReader reader = Database.GetData("ConnectionString-Customer", sql);

            while (reader.Read())
            {
                list.Add(Create(reader));
            }

            reader.Close();
            return list;
        }

        //insert sale into DB
        public static void InsertSale(Sale s)
        {
            string sql = "INSERT INTO Sales VALUES(@Timestamp, @CustomerID, @RegisterID, @ProductID, @Amount, @Price, @TotalPrice)";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@Timestamp", DateTimeToUnixTimeStamp(s.TimeStamp));
            DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@CustomerID", s.CustomerID);
            DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@RegisterID", s.RegisterID);
            DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@ProductID", s.ProductID);
            DbParameter par5 = Database.AddParameter("ConnectionString-Customer", "@Amount", s.Amount);
            DbParameter par6 = Database.AddParameter("ConnectionString-Customer", "@Price", s.Price);
            DbParameter par7 = Database.AddParameter("ConnectionString-Customer", "@TotalPrice", s.TotalPrice);

            Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3, par4, par5, par6, par7);
        }

        //create sale
        private static Sale Create(IDataRecord record)
        {
            return new Sale()
            {
                Id = Int32.Parse(record["ID"].ToString()),
                TimeStamp = UnixTimeStampToDateTime(Int32.Parse(record["Timestamp"].ToString())),
                CustomerID = Int32.Parse(record["CustomerID"].ToString()),
                RegisterID = Int32.Parse(record["RegisterID"].ToString()),
                RegisterName = RegisterDA.GetRegister(Int32.Parse(record["RegisterID"].ToString())).RegisterName,
                ProductID = Int32.Parse(record["ProductID"].ToString()),
                ProductName = ProductDA.GetProduct(Int32.Parse(record["ProductID"].ToString())).ProductName,
                Amount = Int32.Parse(record["Amount"].ToString()),
                Price = Double.Parse(record["Price"].ToString()),
                TotalPrice = Double.Parse(record["TotalPrice"].ToString())
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