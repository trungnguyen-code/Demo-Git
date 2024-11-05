using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_63134865.Models
{
    public class CartItem_63134865
    {
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh { get; set; }
        public string DonGia { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien
        {
            get
            {
                return SoLuong * Int32.Parse(DonGia);
            }
        }
    }
}