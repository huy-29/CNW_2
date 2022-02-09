using CNW_2.Models.DAO;
using CNW_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session["ThongTinDangNhap"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string TenDangNhap, string MatKhau)
        {
            LoginDAO dao = new LoginDAO();
            TaiKhoan_Info user = dao.check_DangNhap(TenDangNhap, MatKhau);

            if (user != null)
            {
                Session["ThongTinDangNhap"] = user;
                if(user.ChucVu == "KhachHang")
                {
                    return RedirectToAction("Index", "Client");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không chính xác";
                return View("Index");
            }
        }
    }
}