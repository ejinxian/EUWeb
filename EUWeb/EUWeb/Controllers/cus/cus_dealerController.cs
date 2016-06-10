using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EUWeb.Models;

namespace EUWeb.Controllers
{
    public class cus_dealerController : Controller
    {
        private vw_sec_user db = new vw_sec_user();

        // GET: cus_dealer
        public ActionResult Index()
        {
            return View(db.cus_dealer.ToList());
        }

        // GET: cus_dealer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cus_dealer cus_dealer = db.cus_dealer.Find(id);
            if (cus_dealer == null)
            {
                return HttpNotFound();
            }
            return View(cus_dealer);
        }

        // GET: cus_dealer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: cus_dealer/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DealerId,CardRangeMode,DealerName,Email,Pwd,CreateTime,CompanyId")] cus_dealer cus_dealer)
        {
            if (ModelState.IsValid)
            {
                db.cus_dealer.Add(cus_dealer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cus_dealer);
        }

        // GET: cus_dealer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cus_dealer cus_dealer = db.cus_dealer.Find(id);
            if (cus_dealer == null)
            {
                return HttpNotFound();
            }
            return View(cus_dealer);
        }

        // POST: cus_dealer/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DealerId,CardRangeMode,DealerName,Email,Pwd,CreateTime,CompanyId")] cus_dealer cus_dealer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cus_dealer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cus_dealer);
        }

        // GET: cus_dealer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cus_dealer cus_dealer = db.cus_dealer.Find(id);
            if (cus_dealer == null)
            {
                return HttpNotFound();
            }
            return View(cus_dealer);
        }

        // POST: cus_dealer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cus_dealer cus_dealer = db.cus_dealer.Find(id);
            db.cus_dealer.Remove(cus_dealer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
