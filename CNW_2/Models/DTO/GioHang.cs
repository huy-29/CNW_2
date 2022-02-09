using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_2.Models.DTO
{
    public class GioHang
    {
        Model1 db = new Model1();
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string AnhBia { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoLuongTon { get; set; }
        public int SoLuong { get; set; }
        public decimal? ThanhTien
        {
            get { return SoLuong * GiaBan; }
        }
        public GioHang()
        {

        }
        public GioHang(int MaSach, int SoLuong)
        {
            this.MaSach = MaSach;
            Sach sach = db.Sach.SingleOrDefault(n => n.MaSach == MaSach);
            this.TenSach = sach.TenSach;
            this.AnhBia = sach.AnhBia;
            this.GiaBan = sach.GiaBan;
            this.SoLuongTon = sach.SoLuongTon;
            this.SoLuong = SoLuong;
        }
    }
}