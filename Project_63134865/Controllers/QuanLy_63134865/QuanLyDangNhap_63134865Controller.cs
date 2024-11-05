using Project_63134865.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63134865.Controllers.QuanLy_63134865
{

    public class QuanLyDangNhap_63134865Controller : Controller
    {
        Project_63134865Entities db = new Project_63134865Entities();
        // GET: QuanLyDangNhap_63134865
        public ActionResult DangNhapQL_63134865()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DangNhapQL_63134865(QuanLy Login)
        {
            try
            {
                var model = db.QuanLies.SingleOrDefault(a => a.TkQL.Equals(Login.TkQL));
                if (model != null)
                {
                    if (model.MkQL.Equals(Login.MkQL))
                    {
                        Session["TkQL"] = model.TkQL;
                        Session["fullName"] = model.HoTenQL;
                        return RedirectToAction("TrangQuanLy_63134865", "QuanLyDangNhap_63134865");
                    }
                    else
                    {
                        Session["TkQL"] = null;
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                    }
                }
                else
                {
                    Session["TkQL"] = null;
                    ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                }
            }
            catch (Exception)
            {
                Session["TkQL"] = null;
                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }
        // Trang Quan Ly
        public ActionResult TrangQuanLy_63134865()
        {
            if (Session["TkQL"] == null)
            {
                Session["TkQL"] = null;
                return RedirectToAction("DangNhapQL_63134865", "QuanLy_63134865");
            }
            else
            {
                return View();
            }
        }
        //DangXuat
        public ActionResult DangXuatQL_63134865()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session["TkQL"] = null;
            return RedirectToAction("DangNhapQL_63134865", "QuanLyDangNhap_63134865");
        }
    }
}