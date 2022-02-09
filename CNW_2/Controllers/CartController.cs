using CNW_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_2.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        public ActionResult Index()
        {
            //List<GioHang> lstGioHang = new List<GioHang>() {
            //    new GioHang { MaSach = 1, TenSach = "thử 1", AnhBia = "gahama.png", GiaBan = 12000, SoLuong = 1, SoLuongTon = 12 },
            //    new GioHang { MaSach = 2, TenSach = "thử 1", AnhBia = "gahama.png", GiaBan = 12000, SoLuong = 3, SoLuongTon = 12 },
            //    new GioHang { MaSach = 3, TenSach = "thử 1", AnhBia = "gahama.png", GiaBan = 12000, SoLuong = 6, SoLuongTon = 12 },
            //    new GioHang { MaSach = 4, TenSach = "thử 1", AnhBia = "gahama.png", GiaBan = 12000, SoLuong = 2, SoLuongTon = 12 },
            //    new GioHang { MaSach = 5, TenSach = "thử 1", AnhBia = "gahama.png", GiaBan = 12000, SoLuong = 4, SoLuongTon = 12 },
            //};
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        [HttpPost]
        public EmptyResult SetSession(string name, string value)
        {
            Session[name] = value;

            return null;
        }

        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        [HttpPost]
        public JsonResult ThemGioHang(int MaSach, int SoLuong)
        {
            List<GioHang> lstGioHang = LayGioHang();

            if(db.Sach.SingleOrDefault(n => n.MaSach == MaSach) == null)
            {
                return Json(false);
            }

            GioHang sach = lstGioHang.Find(n => n.MaSach == MaSach);
            if (sach == null)
            {
                sach = new GioHang(MaSach, SoLuong);
                lstGioHang.Add(sach);
                Session["numberCartItems"] = Convert.ToInt32(Session["numberCartItems"]) + 1;
                return Json("newItem");
            }
            else
            {
                sach.SoLuong = sach.SoLuong + SoLuong;
                return Json("availableItem");
            }
        }

        [HttpPost]
        public EmptyResult CapNhatGioHang(int MaSach, int SoLuong)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sach = lstGioHang.Find(n => n.MaSach == MaSach);
            
            if(sach != null)
            {
                sach.SoLuong = SoLuong;
            }
            
            return null;
        }

        public JsonResult XoaGioHang(int MaSach)
        {
            List<GioHang> lstGioHang = LayGioHang();

            GioHang sach = lstGioHang.Find(n => n.MaSach == MaSach);

            if (sach != null)
            {
                lstGioHang.RemoveAll(n => n.MaSach == MaSach);
                Session["numberCartItems"] = Convert.ToInt32(Session["numberCartItems"]) - 1;
                return Json(true);
            }
            return Json(false);
        }
    }
}