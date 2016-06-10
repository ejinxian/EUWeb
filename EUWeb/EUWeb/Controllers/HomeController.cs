using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EUWeb.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult About()
        {
            ViewBag.Message = "关于";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系我们";

            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Title = "订单管理";
            return View();
        }
        public ActionResult supplierBatchShipments()
        {
            ViewBag.Title = "批量发货";

            return View();
        }
        public ActionResult supplierComplaint()
        {
            ViewBag.Title = "投诉管理";
            return View();
        }
        public ActionResult supplierCheckAccount()
        {
            ViewBag.Title = "对账明细";
            return View();
        }
        /// <summary>
        /// 经销商-预付账户
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerAccount()
        {
            ViewBag.Title = "预付账户";
            return View();
        }
        /// <summary>
        /// 经销商-批量开卡
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerBatchCard()
        {
            ViewBag.Title = "批量开卡";
            return View();
        }
        /// <summary>
        /// 经销商-订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerOrder()
        {
            ViewBag.Title = "订单管理";
            return View();
        }
        /// <summary>
        /// 经销商-订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerSalesReport()
        {
            ViewBag.Title = "销售报表";
            return View();
        }
        /// <summary>
        /// 经销商-订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerProduct()
        {
            ViewBag.Title = "产品资料";
            return View();
        }
        /// <summary>
        /// 经销商-订单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult dealerBatchShipments()
        {
            ViewBag.Title = "批量发货";
            return View();
        }
        /// <summary>
        /// exchange 兑换积分
        /// </summary>
        /// <returns></returns>
        public ActionResult exchange() {
            return View();
        }
        /// <summary>
        /// 兑换商品
        /// </summary>
        /// <returns></returns>
        public ActionResult exchangeCommodity() {
            return View();
        }
        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult aboutUs() {
            return View();
        }
        /// <summary>
        /// 商品详情
        /// </summary>
        /// <returns></returns>
        public ActionResult commodityDetails() {
            return View();
        }
        /// <summary>
        /// 购物车
        /// </summary>
        /// <returns></returns>
        public ActionResult shoppingCart() {
            return View();
        }
        /// <summary>
        /// 下订单
        /// </summary>
        /// <returns></returns>
        public ActionResult shoppingOrder() {
            return View();
        }

    }
}