using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63134865.Models;

namespace Project_63134865.Controllers.QuanLy_63134865
{
    public class QuanLyDonHang_63134865Controller : Controller
    {
        private Project_63134865Entities db = new Project_63134865Entities();

        // GET: QuanLyDonHang_63134865
        public ActionResult Index(string tenKH ="" , string trangthai="" , string donHang ="")
        {
            if (donHang != "")
            {
                var donDatHang = db.DonDatHangs.Include(d => d.KhachHang).Where(d => d.MaDDH.ToUpper().Contains(donHang.ToUpper()));
                return View(donDatHang.ToList());
            }

            if (trangthai != "")
            {
                var donDatHang = db.DonDatHangs.Include(d => d.KhachHang).Where(d => d.TrangThaiDDH.ToUpper().Contains(trangthai.ToUpper()));
                return View(donDatHang.ToList());
            }
            else if (tenKH != "")
            {
                var donDatHang = db.DonDatHangs.Include(d => d.KhachHang).Where(d => d.KhachHang.HoTenKH.ToUpper().Contains(tenKH.ToUpper()));
                return View(donDatHang.ToList());
            }

            var donDatHangs = db.DonDatHangs.Include(d => d.KhachHang);
            return View(donDatHangs.ToList());
        }

        // GET: QuanLyDonHang_63134865/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // GET: QuanLyDonHang_63134865/Create
        public ActionResult Create()
        {
            ViewBag.SdtKH = new SelectList(db.KhachHangs, "SdtKH", "HoTenKH");
            return View();
        }

        // POST: QuanLyDonHang_63134865/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,SdtKH,TinNhanDDH,NgayGioDDH,TrangThaiDDH")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHangs.Add(donDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SdtKH = new SelectList(db.KhachHangs, "SdtKH", "HoTenKH", donDatHang.SdtKH);
            return View(donDatHang);
        }

        // GET: QuanLyDonHang_63134865/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.SdtKH = new SelectList(db.KhachHangs, "SdtKH", "HoTenKH", donDatHang.SdtKH);
            return View(donDatHang);
        }

        // POST: QuanLyDonHang_63134865/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,SdtKH,TinNhanDDH,NgayGioDDH,TrangThaiDDH")] DonDatHang donDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SdtKH = new SelectList(db.KhachHangs, "SdtKH", "HoTenKH", donDatHang.SdtKH);
            return View(donDatHang);
        }

        // GET: QuanLyDonHang_63134865/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return HttpNotFound();
            }
            return View(donDatHang);
        }

        // POST: QuanLyDonHang_63134865/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            db.DonDatHangs.Remove(donDatHang);
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
