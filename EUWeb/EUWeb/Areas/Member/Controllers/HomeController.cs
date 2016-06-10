using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 主页面
        /// </summary>
        /// <returns></returns>
        // GET: Member/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}