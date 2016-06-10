using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Web.Mvc;
using System.Data.SqlClient;
using DbAccess.Sql;
using DbAccess;

namespace EUWeb.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string test = "234";
            Console.WriteLine(test);
            test = "2345";
            Console.WriteLine(test);
            Console.WriteLine(3);
            string sql = "SELECT * FROM `cus_dealer`";
            // int ds = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), sql, "");     
            // DbAccess.Sql.MySQLDatabase ds = new DbAccess.Sql.MySQLDatabase();
            DataTable set = ServiceDB.ExecuteSql(sql);
            if (set.Rows.Count > 0)
            {
                Console.WriteLine(1);
            }
        }
        [TestMethod]
        static void Main(string[] args)
        {
            Console.WriteLine("XXX");
        }
    }
}
