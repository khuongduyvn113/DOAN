using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOAN2.Models;

namespace DOAN2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HeDaoTaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HeDaoTaos
        public ActionResult Index()
        {
            return View(db.HeDaoTaos.ToList());
        }



        // GET: HeDaoTaos/Create
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,HDT")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.HeDaoTaos.Add(heDaoTao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(heDaoTao);
        }

        // GET: HeDaoTaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,HDT")] HeDaoTao heDaoTao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heDaoTao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(heDaoTao);
        }

        // GET: HeDaoTaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            if (heDaoTao == null)
            {
                return HttpNotFound();
            }
            return View(heDaoTao);
        }

        // POST: HeDaoTaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HeDaoTao heDaoTao = db.HeDaoTaos.Find(id);
            db.HeDaoTaos.Remove(heDaoTao);
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
