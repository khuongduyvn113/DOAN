using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOAN2.Models;
using System.IO;

namespace DOAN2.Controllers
{
    
    public class DoAnsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DoAns

        public ActionResult Index()
        {
            var doAns = db.DoAns.Include(d => d.SinhVien.Lop.ChuyenNganh.Khoa).Include(d => d.SinhVien.Lop.ChuyenNganh).Include(d => d.SinhVien.Lop);
            return View(doAns.ToList());
        }



        // GET: DoAns/Create
        public ActionResult Create()
        {
            ViewBag.SinhVienId = new SelectList(db.SinhViens, "Id", "Name");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( HttpPostedFileBase Image, [Bind(Include = "Id,Image,Name,MDA,Human,Score,Humans,SinhVienId")] DoAn doAn)
        {
             string imagePath = "/Scripts/DoAn/doan.jpg";
            if (Image != null && Image.ContentLength > 0)
            {
                imagePath = "/Scripts/DoAn/" + Image.FileName;
                string path = Path.Combine(Server.MapPath("~/Scripts/DoAn"), Image.FileName);
                Image.SaveAs(path);
                doAn.Image = imagePath;
            }

            var newdoAn = new DoAn()
            {
                Name = doAn.Name,
                MDA=doAn.MDA,
                Human=doAn.Human,
                Score=doAn.Score,
                Humans=doAn.Humans,
                SinhVienId=doAn.SinhVienId,
                Image = imagePath,
             };

            if (ModelState.IsValid)
            {
                db.DoAns.Add(newdoAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SinhVienId = new SelectList(db.SinhViens, "Id", "Name");
            return View(doAn);
        }

        // GET: DoAns/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoAn doAn = db.DoAns.Find(id);
            if (doAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.SinhVienId = new SelectList(db.SinhViens, "Id", "Name");
            return View(doAn);
        }

        // POST: DoAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Image,Name,MDA,Human,Score,Humans,SinhVienId")] DoAn doAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SinhVienId = new SelectList(db.SinhViens, "Id", "Name");
            return View(doAn);
        }

        // GET: DoAns/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoAn doAn = db.DoAns.Find(id);
            if (doAn == null)
            {
                return HttpNotFound();
            }
            return View(doAn);
        }

        // POST: DoAns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            DoAn doAn = db.DoAns.Find(id);
            db.DoAns.Remove(doAn);
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
