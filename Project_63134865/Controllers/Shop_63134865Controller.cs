using Project_63134865.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using System.Data.Entity.Migrations;
using Microsoft.Ajax.Utilities;
using Project_63134865.Models;
using System.Reflection;


namespace Project_63134865.Controllers
{
    public class Shop_63134865Controller : Controller
    {
        // GET: Shop_63134865


        // GIỎ HÀNG
        Project_63134865Entities db = new Project_63134865Entities();
        public ActionResult GioHang_63134865()
        {
            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;
            return View(giohang);

        }
        public ActionResult ThemVaoGio(string SanPhamID)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<CartItem_63134865>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }

            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;  // Gán qua biến giohang dễ code

            // Kiểm tra xem sản phẩm khách đang chọn đã có trong giỏ hàng chưa

            if (giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID) == null) // Không có sản phẩm trong giỏ hàng
            {
                SanPham sp = db.SanPhams.Find(SanPhamID);  // Tìm sản phẩm theo SanPhamID

                CartItem_63134865 newItem = new CartItem_63134865()
                {
                    SanPhamID = SanPhamID,
                    TenSanPham = sp.TenSP,
                    SoLuong = 1,
                    Hinh = sp.AnhSP,
                    DonGia = (Int32.Parse(sp.GiaSP) - (Int32.Parse(sp.GiaSP) * sp.GiamGiaSP) / 100).ToString()

                };  // Tạo ra 1 CartItem mới

                giohang.Add(newItem);  // Thêm CartItem vào giỏ 
            }
            else
            {
                // Nếu sản phẩm khách chọn đã có trong giỏ hàng thì không thêm vào giỏ nữa mà tăng số lượng lên.
                CartItem_63134865 cardItem = giohang.FirstOrDefault(m => m.SanPhamID == SanPhamID);
                cardItem.SoLuong++;
            }

            // Action này sẽ chuyển hướng về trang chi tiết sản phẩm khi khách hàng đặt vào giỏ thành công. Có thể chuyển về chính trang khách hàng vừa đứng bằng lệnh return Redirect(Request.UrlReferrer.ToString()); nếu muốn.
            return Redirect(Request.UrlReferrer.ToString());
        }
        //Sửa số lượng
        public ActionResult SuaSoLuong(string SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;
            CartItem_63134865 itemSua = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));
            if (itemSua != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    itemSua.SoLuong = soluongmoi;
                }
            }
            return RedirectToAction("GioHang_63134865");

        }
        //Xoá khỏi giỏ
        public ActionResult XoaKhoiGio(string SanPhamID)
        {
            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;
            CartItem_63134865 itemXoa = giohang.FirstOrDefault(m => m.SanPhamID.Equals(SanPhamID));
            if (itemXoa != null)
            {
                giohang.Remove(itemXoa);
            }
            return RedirectToAction("GioHang_63134865");
        }




        /// TRANG CHỦ
        public ActionResult TrangChu_63134865()
        {
            return View();
        }



        // HIỂN THỊ SẢN PHẨM
        // Hiển thị sản phẩm theo tên sản phẩm 
        public ActionResult SanPhamTheoLSP_63134865(int id, int? page)
        {
            ViewBag.typeName = db.LoaiSanPhams.SingleOrDefault(t => t.MaLSP == id).TenLSP;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.SanPhams.Where(t => t.MaLSP == id).OrderByDescending(x => x.MaLSP).ToPagedList(pageNumber, pageSize));
        }
        // Hiển thị sản phẩm theo nhà sản xuất
        public ActionResult SanPhamTheoHSX_63134865(int id, int? page)
        {
            ViewBag.pdcName = db.HangSanXuats.SingleOrDefault(c => c.MaHSX == id).TenHSX;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.SanPhams.Where(p => p.MaHSX == id).OrderByDescending(x => x.MaHSX).ToPagedList(pageNumber, pageSize));
        }
        // Tìm kiếm theo sản phẩm
        public ActionResult TimKiem_63134865(string name, int? page)
        {
            ViewBag.search = name;
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(db.SanPhams.Where(p => p.TenSP.Contains(name)).OrderByDescending(x => x.TenSP).ToPagedList(pageNumber, pageSize));
        }
        // Hiển thị chi tiết sản phẩm
        public ActionResult ChiTietSP_63134865(string id)
        {
            return View(db.SanPhams.SingleOrDefault(p => p.MaSP.Equals(id)));
        }




        /// THANH TOÁN
        public ActionResult ThanhToan_63134865()
        {
            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;
            return View(giohang);
        }

        [HttpPost]
        public ActionResult Gui_63134865()
        {
            //Nhận reqest từ trang index
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            //kiểm tra xem có customer chưa và cập nhật lại
            KhachHang newCus = new KhachHang();
            var cus = db.KhachHangs.FirstOrDefault(p => p.SdtKH.Equals(phone));
            if (cus != null)
            {
                //nếu có số điện thoại trong db rồi
                //cập nhật thông tin và lưu
                cus.HoTenKH = fullname;
                cus.EmailKH = email;
                cus.DiaChiKH = address;
                db.Entry(cus).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                //nếu chưa có sđt trong db
                //thêm thông tin và lưu
                newCus.SdtKH = phone;
                newCus.HoTenKH = fullname;
                newCus.EmailKH = email;
                newCus.DiaChiKH = address;
                db.KhachHangs.Add(newCus);
                db.SaveChanges();
            }

            //Thêm thông tin vào order và orderdetail
            List<CartItem_63134865> giohang = Session["giohang"] as List<CartItem_63134865>;
            //thêm order mới
            DonDatHang newOrder = new DonDatHang();
            string newIDOrder = (Int32.Parse(db.DonDatHangs.OrderByDescending(p => p.NgayGioDDH).FirstOrDefault().MaDDH.Replace("HD", "")) + 20).ToString();
            newOrder.MaDDH = "HD" + newIDOrder;
            newOrder.SdtKH = phone;
            newOrder.TinNhanDDH = note;
            newOrder.NgayGioDDH = DateTime.Now.ToString("");
            newOrder.TrangThaiDDH = "Chờ xác nhận";
            db.DonDatHangs.AddOrUpdate(newOrder);
            db.SaveChanges();

            //thêm details
            for (int i = 0; i < giohang.Count; i++)
            {
                DonDatHangChiTiet newOrdts = new DonDatHangChiTiet();
                newOrdts.MaDDH = newOrder.MaDDH;
                newOrdts.MaSP = giohang.ElementAtOrDefault(i).SanPhamID;
                newOrdts.SoLuongDDHCT = giohang.ElementAtOrDefault(i).SoLuong;
                newOrdts.ThanhTienDDHCT = giohang.ElementAtOrDefault(i).ThanhTien.ToString();
                db.DonDatHangChiTiets.AddOrUpdate(newOrdts);
                db.SaveChanges();
            }
            Session["MHD"] = "HD" + newIDOrder;
            Session["Phone"] = phone;
            //xoá sạch giỏ hàng
            giohang.Clear();
            return RedirectToAction("HoaDon_63134865", "Shop_63134865");
        }





        // HÓA ĐƠN
        public ActionResult HoaDon_63134865()
        {
            return View();
        }


        /// ĐĂNG KÝ
        public ActionResult DangKy_63134865()
        {
            return View();
        }
        //POST: ĐĂNG KÝ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy_63134865(KhachHang cus)
        {

            //
            try
            {
                if (ModelState.IsValid)
                {
                    var check = db.KhachHangs.FirstOrDefault(s => s.EmailKH == cus.EmailKH);
                    if (check == null)
                    {
                        cus.PassKH = GetMD5(cus.PassKH);
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.KhachHangs.Add(cus);
                        db.SaveChanges();
                        return RedirectToAction("DangNhap_63134865");
                    }
                    else
                    {
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                        return View();
                    }
                }
            }
            catch (Exception)
            {

                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();

        }

        /// TẠO MÃ HÓA KÝ TỰ CHUẨN MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }



        /// ĐĂNG NHẬP 
        public ActionResult DangNhap_63134865()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DangNhap_63134865(KhachHang login)
        {
            try
            {
                var model = db.KhachHangs.SingleOrDefault(a => a.EmailKH.Equals(login.EmailKH));
                if (model != null)
                {
                    var md5cusPass = GetMD5(login.PassKH);
                    if (model.PassKH.Equals(md5cusPass) || model.PassKH.Equals(login.PassKH )) 
                    {
                        Session["Email"] = model.EmailKH;
                        Session["fullName"] = model.HoTenKH;
                        return RedirectToAction("TrangChu_63134865", "Shop_63134865");
                    }
                    else
                    {
                        Session["Email"] = null;
                        ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                    }
                }
                else
                {
                    Session["Email"] = null;
                    ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
                }
            }
            catch (Exception)
            {
                Session["Email"] = null;
                ViewBag.LoginError = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }


        // ĐĂNG XUÁT
        public ActionResult DangXuat_63134865()
        {
            Session.Clear();//remove session
            return RedirectToAction("DangNhap_63134865");
        }
    }
}
