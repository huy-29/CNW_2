using CNW_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace CNW_2.Models.DAO
{
    public class AdminDAO
    {
        Model1 db;
        public AdminDAO()
        {
            db = new Model1();
        }
        public IEnumerable<Sach_AdminIndex> listSach_Admin(int pageNum, int pageSize)
        {
            string q = "EXEC dbo.Sach_Admin";
            var lst = db.Database.SqlQuery<Sach_AdminIndex>(q).ToPagedList<Sach_AdminIndex>(pageNum, pageSize);

            return lst;
        }
        public int new_MaSach()
        {
            string q = "SELECT dbo.TaoMoiMaSach()";
            return db.Database.SqlQuery<int>(q).FirstOrDefault();
        }
        public void Update_Sach(int? MaSach, string TenSach, decimal GiaBan, string MoTa, string AnhBia, int SoLuongTon, string NSX, string DS_TacGia, string DS_TheLoai)
        {
            string MaSach_Insert = "null";
            if(MaSach != null)
            {
                MaSach_Insert = MaSach.ToString();
            }
            string q = "EXEC dbo.ThemSua_Sach @MaSach = " + MaSach_Insert + ", @TenSach = N'" + TenSach + "', @GiaBan = " + GiaBan + ", @MoTa = N'" + MoTa + "', @AnhBia = N'" + AnhBia + "', @SoLuongTon = " + SoLuongTon + ", @TenNXB = N'" + NSX + "', @DS_TenTG = N'" + DS_TacGia + "', @DS_TenTheLoai = N'" + DS_TheLoai + "'";
            db.Database.ExecuteSqlCommand(q);
        }
        public void Delete_Sach(int MaSach)
        {
            string q = "EXEC dbo.Xoa_Sach @MaSach = " + MaSach;
            db.Database.ExecuteSqlCommand(q);
        }
        public IEnumerable<TacGia> list_TacGia()
        {
            string q = "SELECT * FROM dbo.TacGia";
            var lst = db.Database.SqlQuery<TacGia>(q).ToList<TacGia>();
            return lst;
        }
        public IEnumerable<TheLoai> list_TheLoai()
        {
            string q = "SELECT * FROM dbo.TheLoai";
            var lst = db.Database.SqlQuery<TheLoai>(q).ToList<TheLoai>();
            return lst;
        }
        public IEnumerable<NhaXuatBan> list_NXB()
        {
            string q = "SELECT * FROM dbo.NhaXuatBan";
            var lst = db.Database.SqlQuery<NhaXuatBan>(q).ToList<NhaXuatBan>();
            return lst;
        }
        public Sach_AdminIndex ChiTietSach(int MaSach)
        {
            string q = "EXEC dbo.Sach_Admin_Detail @MaSach = " + MaSach;
            var lst = db.Database.SqlQuery<Sach_AdminIndex>(q).FirstOrDefault();
            return lst;
        }
        public IEnumerable<Sach_AdminIndex> listSach_Admin_TimKiem(int pageNum, int pageSize, string TenSach, string Min, string Max, string TheLoai, string TacGia, string NXB)
        {
            string q = "EXEC dbo.Sach_Admin_TimKiem @TimTenSach = N'" + TenSach + "', @Min = '" + Min + "', @Max = '" + Max + "', @TimTheLoai = N'" + TheLoai + "', @TimTacGia = N'" + TacGia + "', @TimNXB = N'" + NXB + "'";
            var lst = db.Database.SqlQuery<Sach_AdminIndex>(q).ToPagedList<Sach_AdminIndex>(pageNum, pageSize);

            return lst;
        }
    }
}