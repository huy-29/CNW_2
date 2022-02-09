using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNW_2.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        //Trang nhập hàng
        public ActionResult TestTable()
        {
            return View();
        }

        //Trang index
        public ActionResult TestTable_Index()
        {
            return View();
        }

        //Trang chính client_hiện danh sách hàng
        public ActionResult Test_Client()
        {
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string DN, string MK)
        {
            if(DN == "abc" && MK == "123")
            {
                return View("Test_Client");
            }
            return View();
        }
    }
}