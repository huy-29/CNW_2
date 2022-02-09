using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CNW_2.Models.DTO
{
    public class TaiKhoan_Info
    {
        public int MaTK { get; set; }
        public int? MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string ChucVu { get; set; }
    }
}