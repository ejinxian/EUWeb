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
    public class bas_cityController : Controller
    {
        private vw_sec_user db = new vw_sec_user();

        // GET: bas_city
        public ActionResult Index()
        {
            return View(db.bas_city.ToList());
        }

        // GET: bas_city/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bas_city bas_city = db.bas_city.Find(id);
            if (bas_city == null)
            {
                return HttpNotFound();
            }
            return View(bas_city);
        }

        // GET: bas_city/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bas_city/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,ProvinceId,Code,CityName,Disabled")] bas_city bas_city)
        {
            if (ModelState.IsValid)
            {
                db.bas_city.Add(bas_city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bas_city);
        }

        // GET: bas_city/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bas_city bas_city = db.bas_city.Find(id);
            if (bas_city == null)
            {
                return HttpNotFound();
            }
            return View(bas_city);
        }

        // POST: bas_city/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,ProvinceId,Code,CityName,Disabled")] bas_city bas_city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bas_city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bas_city);
        }

        // GET: bas_city/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bas_city bas_city = db.bas_city.Find(id);
            if (bas_city == null)
            {
                return HttpNotFound();
            }
            return View(bas_city);
        }

        // POST: bas_city/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bas_city bas_city = db.bas_city.Find(id);
            db.bas_city.Remove(bas_city);
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
