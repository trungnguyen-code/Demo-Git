using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63134865.Models;

namespace Project_63134865.Controllers.QuanLy_63134865
{
    public class QuanLyDanhMuc_63134865Controller : Controller
    {
        private Project_63134865Entities db = new Project_63134865Entities();

        // GET: QuanLyDanhMuc_63134865
        public ActionResult Index(string error , string tenDM ="")
        {
            if (tenDM != "")
            {
                var danhMuc = db.DanhMucs.Where(a => a.TenDM.ToUpper().Contains(tenDM.ToUpper()));
                return View(danhMuc.ToList());
            }


            ViewBag.CateError = error;
            var modelCate = db.DanhMucs.ToList();
            return View(modelCate);
        }

        // GET: QuanLyDanhMuc_63134865/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // GET: QuanLyDanhMuc_63134865/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLyDanhMuc_63134865/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDM,TenDM,AnhDM")] DanhMuc danhMuc, HttpPostedFileBase file)
        {

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    try
                    {
                        string nameFile = Path.GetFileName(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath("/Image/"), nameFile));
                        danhMuc.AnhDM = "/Image/" + nameFile;
                    }
                    catch (Exception)
                    {
                        ViewBag.CreateCategory = "Không thể chọn ảnh.";
                    }
                }
                try
                {
                    if (db.DanhMucs.SingleOrDefault(a => a.TenDM.Equals(danhMuc.TenDM)) == null)
                    {
                        db.DanhMucs.AddOrUpdate(danhMuc);
                        db.SaveChanges();
                        ViewBag.Create = "Thêm danh mục thành công.";
                    }
                    else
                    {
                        ViewBag.Create = "Tên danh mục đã tồn tại.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.Create = "Không thể thêm danh mục.";
                }
            }
            else
            {
                ViewBag.HinhAnh = "Vui lòng chọn hình ảnh.";
            }
            return View();
        }

        // GET: QuanLyDanhMuc_63134865/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: QuanLyDanhMuc_63134865/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDM,TenDM,AnhDM")] DanhMuc danhMuc, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    try
                    {
                        string nameFile = Path.GetFileName(file.FileName);
                        file.SaveAs(Path.Combine(Server.MapPath("/Image/"), nameFile));
                        danhMuc.AnhDM = "/Image/" + nameFile;
                    }
                    catch (Exception)
                    {
                        ViewBag.Create = "Không thể chọn ảnh.";
                    }
                }
                try
                {
                    if (db.DanhMucs.SingleOrDefault(a => a.TenDM.Equals(danhMuc.TenDM)) == null)
                    {
                        db.DanhMucs.AddOrUpdate(danhMuc);
                        db.SaveChanges();
                        ViewBag.Create = "Cập nhật danh mục thành công.";
                    }
                    else
                    {
                        ViewBag.Create = "Tên danh mục đã tồn tại.";
                    }
                }
                catch (Exception)
                {
                    ViewBag.Create = "Không thể cập nhật danh mục.";
                }
            }
            else
            {
                ViewBag.HinhAnh = "Vui lòng chọn hình ảnh.";
            }
            return View();
        }


        // GET: QuanLyDanhMuc_63134865/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        // POST: QuanLyDanhMuc_63134865/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var model = db.DanhMucs.SingleOrDefault(a => a.MaDM.Equals(id));
            try
            {
                if (model != null)
                {
                    db.DanhMucs.Remove(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "QuanLyDanhMuc_63134865", new { error = "Xoá danh mục thành công." });
                }
                else
                {
                    return RedirectToAction("Index", "QuanLyDanhMuc_63134865", new { error = "Danh mục không tồn tại." });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "QuanLyDanhMuc_63134865", new { error = "Không thể xoá danh mục." });
            }
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
