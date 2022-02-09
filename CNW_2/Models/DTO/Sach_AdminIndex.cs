using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_2.Models.DTO
{
    public class Sach_AdminIndex
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public decimal? GiaBan { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public int? SoLuongTon { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string NXB { get; set; }

    }
}