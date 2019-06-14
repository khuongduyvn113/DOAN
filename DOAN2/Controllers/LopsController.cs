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
    public class LopsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lops
        public ActionResult Index()
        {
            return View(db.Lops.Include(l => l.ChuyenNganh.Khoa).Include(l =>l.NienKhoa).Include(l=>l.HeDaoTao).ToList());
        }



        // GET: Lops/Create
        public ActionResult Create()
        {
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            ViewBag.HeDaoTaoId = new SelectList(db.HeDaoTaos, "Id", "Name");
            ViewBag.NienKhoaId = new SelectList(db.NienKhoas, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameCN,ChuyenNganhId,HeDaoTaoId,NienKhoaId,SS")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            ViewBag.HeDaoTaoId = new SelectList(db.HeDaoTaos, "Id", "Name");
            ViewBag.NienKhoaId = new SelectList(db.NienKhoas, "Id", "Name");
            return View(lop);
        }

        // GET: Lops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            ViewBag.HeDaoTaoId = new SelectList(db.HeDaoTaos, "Id", "Name");
            ViewBag.NienKhoaId = new SelectList(db.NienKhoas, "Id", "Name");
            return View(lop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameCN,,ChuyenNganhId,HeDaoTaoId,NienKhoaId,SS")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            ViewBag.HeDaoTaoId = new SelectList(db.HeDaoTaos, "Id", "Name");
            ViewBag.NienKhoaId = new SelectList(db.NienKhoas, "Id", "Name");
            return View(lop);
        }

        // GET: Lops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChuyenNganhId = new SelectList(db.ChuyenNganhs, "Id", "NameCN");
            ViewBag.HeDaoTaoId = new SelectList(db.HeDaoTaos, "Id", "Name");
            ViewBag.NienKhoaId = new SelectList(db.NienKhoas, "Id", "Name");
            return View(lop);
        }

        // POST: Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lop lop = db.Lops.Find(id);
            db.Lops.Remove(lop);
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
