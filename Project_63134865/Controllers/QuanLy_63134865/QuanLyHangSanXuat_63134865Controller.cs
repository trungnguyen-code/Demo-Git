using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63134865.Models;

namespace Project_63134865.Controllers.QuanLy_63134865
{
    public class QuanLyHangSanXuat_63134865Controller : Controller
    {
        private Project_63134865Entities db = new Project_63134865Entities();

        // GET: QuanLyHangSanXuat_63134865
        public ActionResult Index(string tenHSX ="")
        {
            if (tenHSX != "")
            {
                var hsx = db.HangSanXuats.Where(a => a.TenHSX.ToUpper().Contains(tenHSX.ToUpper()));
                return View(hsx.ToList());
            }


            return View(db.HangSanXuats.ToList());
        }

        // GET: QuanLyHangSanXuat_63134865/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // GET: QuanLyHangSanXuat_63134865/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanLyHangSanXuat_63134865/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHSX,TenHSX,SdtHSX,EmailHSX,DiaChiHSX,AnhHSX")] HangSanXuat hangSanXuat, HttpPostedFileBase anhHSX)
        {
            if (ModelState.IsValid)
            {
                if (anhHSX.FileName != "")
                {
                    //System.Web.HttpPostedFileBase Avatar;
                    var img = Request.Files["anhHSX"];
                    //Lấy thông tin từ input type=file có tên Avatar
                    string postedFileName = System.IO.Path.GetFileName(img.FileName);
                    //Lưu hình đại diện về Server
                    var path = Server.MapPath("/Image/" + postedFileName);
                    img.SaveAs(path);

                    hangSanXuat.AnhHSX = "/Image/" + postedFileName;
                    db.HangSanXuats.AddOrUpdate(hangSanXuat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(hangSanXuat);
        }

        // GET: QuanLyHangSanXuat_63134865/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: QuanLyHangSanXuat_63134865/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHSX,TenHSX,SdtHSX,EmailHSX,DiaChiHSX,AnhHSX")] HangSanXuat hangSanXuat, HttpPostedFileBase anhHSX)
        {
            if (ModelState.IsValid)
            {
                if (anhHSX.FileName != "")
                {
                    //System.Web.HttpPostedFileBase Avatar;
                    var img = Request.Files["anhHSX"];
                    //Lấy thông tin từ input type=file có tên Avatar
                    string postedFileName = System.IO.Path.GetFileName(img.FileName);
                    //Lưu hình đại diện về Server
                    var path = Server.MapPath("/Image/" + postedFileName);
                    img.SaveAs(path);

                    hangSanXuat.AnhHSX = "/Image/" + postedFileName;
                    db.HangSanXuats.AddOrUpdate(hangSanXuat);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(hangSanXuat);
        }

        // GET: QuanLyHangSanXuat_63134865/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            if (hangSanXuat == null)
            {
                return HttpNotFound();
            }
            return View(hangSanXuat);
        }

        // POST: QuanLyHangSanXuat_63134865/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HangSanXuat hangSanXuat = db.HangSanXuats.Find(id);
            db.HangSanXuats.Remove(hangSanXuat);
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
