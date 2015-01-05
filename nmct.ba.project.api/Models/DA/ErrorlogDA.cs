using nmct.ba.cashlessproject.model.Klant;
using nmct.ba.project.api.Helper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace nmct.ba.project.api.Models.DA
{
    public class ErrorlogDA
    {
        //insert employee into DB
        public static void InsertErrorlog(Errorlog e)
        {
            string sql = "INSERT INTO Errorlog VALUES(@RegisterID, @Timestamp, @Message, @StackTrace)";
            DbParameter par1 = Database.AddParameter("ConnectionString-Customer", "@RegisterID", e.RegisterID);
            DbParameter par2 = Database.AddParameter("ConnectionString-Customer", "@Timestamp", e.TimeStamp);
            DbParameter par3 = Database.AddParameter("ConnectionString-Customer", "@Message", e.Message);
            DbParameter par4 = Database.AddParameter("ConnectionString-Customer", "@StackTrace", e.StackTrace);

            Database.InsertData("ConnectionString-Customer", sql, par1, par2, par3, par4);
        }
    }
}