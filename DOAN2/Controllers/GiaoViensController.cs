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
    public class GiaoViensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GiaoViens
        public ActionResult Index()
        {
            var giaoViens = db.GiaoViens.Include(g => g.ChuyenNganh.Khoa);
            return View(giaoViens.ToList());
        }



        // GET: GiaoViens/Create
        public ActionResult Create()
        {
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,SDT,Email,Village,Date,ChuyenNganhId")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                db.GiaoViens.Add(giaoVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            return View(giaoVien);
        }

        // GET: GiaoViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            return View(giaoVien);
        }

        // POST: GiaoViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,SDT,Email,Village,Date,ChuyenNganhId")] GiaoVien giaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giaoVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            return View(giaoVien);
        }

        // GET: GiaoViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            if (giaoVien == null)
            {
                return HttpNotFound();
            }
            return View(giaoVien);
        }

        // POST: GiaoViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiaoVien giaoVien = db.GiaoViens.Find(id);
            db.GiaoViens.Remove(giaoVien);
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
