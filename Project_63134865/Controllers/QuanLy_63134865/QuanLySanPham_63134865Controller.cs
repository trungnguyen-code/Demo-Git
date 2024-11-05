using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63134865.Models;

namespace Project_63134865.Controllers.QuanLy_63134865
{
    public class QuanLySanPham_63134865Controller : Controller
    {
        private Project_63134865Entities db = new Project_63134865Entities();

        // GET: QuanLySanPham_63134865
        public ActionResult Index( string TenSP = "")
        {
            if (TenSP != "")
            {
                var sanPham = db.SanPhams.Include(s => s.HangSanXuat).Include(s => s.LoaiSanPham).Include(s => s.TiLe).Where(s => s.TenSP.ToUpper().Contains(TenSP.ToUpper()));
                return View(sanPham.ToList());
            }

            var sanPhams = db.SanPhams.Include(s => s.HangSanXuat).Include(s => s.LoaiSanPham).Include(s => s.TiLe);
            return View(sanPhams.ToList());
        }
        // GET: QuanLySanPham_63134865/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: QuanLySanPham_63134865/Create
        public ActionResult Create()
        {
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX");
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP");
            ViewBag.MaSP = new SelectList(db.TiLes, "MaSP", "MaSP");
            return View();
        }

        // POST: QuanLySanPham_63134865/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaHSX,MaLSP,TenSP,SizeSP,GiaSP,GiamGiaSP,AnhSP,CapNhatNgayThangSP,MieuTaSP")] SanPham sanPham, HttpPostedFileBase anhSP)
        {
            if (ModelState.IsValid)
            {
                if (anhSP.FileName != "")
                {
                    //System.Web.HttpPostedFileBase Avatar;
                    var img = Request.Files["anhSP"];
                    //Lấy thông tin từ input type=file có tên Avatar
                    string postedFileName = System.IO.Path.GetFileName(img.FileName);
                    //Lưu hình đại diện về Server
                    var path = Server.MapPath("/Image/" + postedFileName);
                    img.SaveAs(path);

                    sanPham.AnhSP = "/Image/" + postedFileName;
                    db.SanPhams.AddOrUpdate(sanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPham.MaHSX);
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            ViewBag.MaSP = new SelectList(db.TiLes, "MaSP", "MaSP", sanPham.MaSP);
            return View(sanPham);
        }

        // GET: QuanLySanPham_63134865/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPham.MaHSX);
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            ViewBag.MaSP = new SelectList(db.TiLes, "MaSP", "MaSP", sanPham.MaSP);
            return View(sanPham);
        }

        // POST: QuanLySanPham_63134865/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaHSX,MaLSP,TenSP,SizeSP,GiaSP,GiamGiaSP,AnhSP,CapNhatNgayThangSP,MieuTaSP")] SanPham sanPham, HttpPostedFileBase anhSP)
        {
            if (ModelState.IsValid)
            {
                if (anhSP.FileName != "")
                {
                    //System.Web.HttpPostedFileBase Avatar;
                    var img = Request.Files["anhSP"];
                    //Lấy thông tin từ input type=file có tên Avatar
                    string postedFileName = System.IO.Path.GetFileName(img.FileName);
                    //Lưu hình đại diện về Server
                    var path = Server.MapPath("/Image/" + postedFileName);
                    img.SaveAs(path);

                    sanPham.AnhSP = "/Image/" + postedFileName;
                    db.SanPhams.AddOrUpdate(sanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MaHSX = new SelectList(db.HangSanXuats, "MaHSX", "TenHSX", sanPham.MaHSX);
            ViewBag.MaLSP = new SelectList(db.LoaiSanPhams, "MaLSP", "TenLSP", sanPham.MaLSP);
            ViewBag.MaSP = new SelectList(db.TiLes, "MaSP", "MaSP", sanPham.MaSP);
            return View(sanPham);
        }

        // GET: QuanLySanPham_63134865/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: QuanLySanPham_63134865/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
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
