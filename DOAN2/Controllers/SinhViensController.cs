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
    public class SinhViensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SinhViens
        public ActionResult Index()
        {
            var sinhViens = db.SinhViens.Include(s => s.Lop.ChuyenNganh.Khoa).Include(s => s.Lop.ChuyenNganh).Include(s => s.Lop.HeDaoTao).Include(s => s.Lop.NienKhoa);
            return View(sinhViens.ToList());
        }



        // GET: SinhViens/Create
        public ActionResult Create()
        {
            ViewBag.LopId = new SelectList(db.Lops, "Id", "NameCN");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SV,Name,SDT,Email,Village,Date,LopId")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.SinhViens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LopId = new SelectList(db.Lops, "Id", "NameCN");
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.LopId = new SelectList(db.Lops, "Id", "NameCN");
            return View(sinhVien);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SV,Name,SDT,Email,Village,Date,LopId")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LopId = new SelectList(db.Lops, "Id", "NameCN");
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.SinhViens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SinhVien sinhVien = db.SinhViens.Find(id);
            db.SinhViens.Remove(sinhVien);
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
