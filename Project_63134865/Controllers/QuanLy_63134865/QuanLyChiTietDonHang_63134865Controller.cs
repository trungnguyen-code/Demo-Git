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
    public class QuanLyChiTietDonHang_63134865Controller : Controller
    {
        private Project_63134865Entities db = new Project_63134865Entities();

        // GET: QuanLyChiTietDonHang_63134865
        public ActionResult Index( string ctdh = "")
        {
            if (ctdh != "")
            {
                var donDatHangChiTiet = db.DonDatHangChiTiets.Include(d => d.DonDatHang).Include(d => d.SanPham).Where(a => a.DonDatHang.MaDDH.ToUpper().Contains(ctdh.ToUpper()));
                return View(donDatHangChiTiet.ToList());
            }

            var donDatHangChiTiets = db.DonDatHangChiTiets.Include(d => d.DonDatHang).Include(d => d.SanPham);
            return View(donDatHangChiTiets.ToList());
        }

        // GET: QuanLyChiTietDonHang_63134865/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHangChiTiet donDatHangChiTiet = db.DonDatHangChiTiets.Find(id);
            if (donDatHangChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(donDatHangChiTiet);
        }

        // GET: QuanLyChiTietDonHang_63134865/Create
        public ActionResult Create()
        {
            ViewBag.MaDDH = new SelectList(db.DonDatHangs, "MaDDH", "SdtKH");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP");
            return View();
        }

        // POST: QuanLyChiTietDonHang_63134865/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDDH,MaSP,SoLuongDDHCT,ThanhTienDDHCT")] DonDatHangChiTiet donDatHangChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.DonDatHangChiTiets.Add(donDatHangChiTiet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDDH = new SelectList(db.DonDatHangs, "MaDDH", "SdtKH", donDatHangChiTiet.MaDDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", donDatHangChiTiet.MaSP);
            return View(donDatHangChiTiet);
        }

        // GET: QuanLyChiTietDonHang_63134865/Edit/5
        public ActionResult Edit(int  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHangChiTiet donDatHangChiTiet = db.DonDatHangChiTiets.Find(id);
            if (donDatHangChiTiet == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDDH = new SelectList(db.DonDatHangs, "MaDDH", "SdtKH", donDatHangChiTiet.MaDDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", donDatHangChiTiet.MaSP);
            return View(donDatHangChiTiet);
        }

        // POST: QuanLyChiTietDonHang_63134865/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDDH,MaSP,SoLuongDDHCT,ThanhTienDDHCT")] DonDatHangChiTiet donDatHangChiTiet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donDatHangChiTiet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDDH = new SelectList(db.DonDatHangs, "MaDDH", "SdtKH", donDatHangChiTiet.MaDDH);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "TenSP", donDatHangChiTiet.MaSP);
            return View(donDatHangChiTiet);
        }

        // GET: QuanLyChiTietDonHang_63134865/Delete/5
        public ActionResult Delete(int  id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonDatHangChiTiet donDatHangChiTiet = db.DonDatHangChiTiets.Find(id);
            if (donDatHangChiTiet == null)
            {
                return HttpNotFound();
            }
            return View(donDatHangChiTiet);
        }

        // POST: QuanLyChiTietDonHang_63134865/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int  id)
        {
            DonDatHangChiTiet donDatHangChiTiet = db.DonDatHangChiTiets.Find(id);
            db.DonDatHangChiTiets.Remove(donDatHangChiTiet);
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
