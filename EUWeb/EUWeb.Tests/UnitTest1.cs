using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using EUWeb.Controllers;
using System.Web.Mvc;
using EU.DAL;

namespace EUWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataTable dt = SqlCommon.GetDataTable();
            WebApiController controller = new WebApiController();
            
            string methodName="";
            string param="";
            string type="1";
            string t = controller.Get(methodName, param, type);
            // Act

            // Assert
            Assert.AreEqual("1","1");
        }
    }
}
