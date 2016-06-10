using EU.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private InterfaceCategoryService categoryRepository;
        public CategoryController() {
            categoryRepository = new CategoryService();
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JsonTree()
        {
            return View();
        }
    }
}