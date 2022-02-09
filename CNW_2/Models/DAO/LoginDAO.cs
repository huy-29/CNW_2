using CNW_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace CNW_2.Models.DAO
{
    public class LoginDAO
    {
        Model1 db;
        public LoginDAO()
        {
            db = new Model1();
        }
        public TaiKhoan_Info check_DangNhap(string TenDangNhap, string MatKhau)
        {
            if(TenDangNhap == "" || MatKhau == "")
            {
                return null;
            }
            string q = "EXEC dbo.Login_Info @TenDangNhap = " + TenDangNhap + ", @MatKhau = " + MatKhau;
            var lst = db.Database.SqlQuery<TaiKhoan_Info>(q).FirstOrDefault();
            return lst;
        }

        public IEnumerable<Sach_AdminIndex> listSach_Admin(int pageNum, int pageSize)
        {
            string q = "EXEC dbo.Sach_Admin";
            var lst = db.Database.SqlQuery<Sach_AdminIndex>(q).ToPagedList<Sach_AdminIndex>(pageNum, pageSize);

            return lst;
        }
        public void Update_Sach(int? MaSach, string TenSach, decimal GiaBan, string MoTa, string AnhBia, int SoLuongTon, string NSX, string DS_TacGia, string DS_TheLoai)
        {
            string MaSach_Insert = "null";
            if (MaSach != null)
            {
                MaSach_Insert = MaSach.ToString();
            }
            string q = "EXEC dbo.ThemSua_Sach @MaSach = " + MaSach_Insert + ", @TenSach = N'" + TenSach + "', @GiaBan = " + GiaBan + ", @MoTa = N'" + MoTa + "', @AnhBia = N'" + AnhBia + "', @SoLuongTon = " + SoLuongTon + ", @TenNXB = N'" + NSX + "', @DS_TenTG = N'" + DS_TacGia + "', @DS_TenTheLoai = N'" + DS_TheLoai + "'";
            db.Database.ExecuteSqlCommand(q);
        }
        public IEnumerable<TheLoai> list_TheLoai()
        {
            string q = "SELECT * FROM dbo.TheLoai";
            var lst = db.Database.SqlQuery<TheLoai>(q).ToList<TheLoai>();
            return lst;
        }
    }
}