using CNW_2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CNW_2.Models.DAO;
using System.IO;

namespace CNW_2.Controllers
{
    public class AdminController : Controller
    {
        Model1 db;
        // GET: Admin
        public ActionResult Index(int? page)
        {
            if (page == null)
            {
                Session["TimTenSach"] = null;
                Session["TimGiaTienMin"] = null;
                Session["TimGiaTienMax"] = null;
                Session["TimTheLoai"] = null;
                Session["TimTacGia"] = null;
                Session["TimNXB"] = null;

                Session["Admin_Index_page"] = null;
                Session["AdminIndex_ScrollTop"] = 0;
            }

            if (page != null)
            {
                if (Session["AdminIndex_action"] == null)
                {
                    Session["AdminIndex_ScrollTop"] = 270;
                }
                else { Session["AdminIndex_action"] = null; }
            }

            AdminDAO dao = new AdminDAO();
            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            Session["Controller"] = "Admin";
            Session["Action"] = "Index";
            Session["Admin_Index_page"] = page;

            int pagesize = 8;
            int pageNumber = (page ?? 1);

            return View(dao.listSach_Admin(pageNumber, pagesize));
        }
        [HttpPost]
        public EmptyResult SetSession(string name, string value)
        {
            //Session["AdminIndex_ScrollTop"] = name;
            Session[name] = value;

            return null;
        }
        public ActionResult Add()
        {
            AdminDAO dao = new AdminDAO();
            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            return View();
        }
        [HttpPost]
        public ActionResult Add(string[] TenSach, string[] GiaBan, string[] MoTa, string[] SoLuong, string[] listTacGia, string[] listTheLoai, string[] NXB, HttpPostedFileBase[] post_AnhBia)
        {
            AdminDAO dao = new AdminDAO();

            int numberOfSach = TenSach.GetLength(0);

            string Path_AnhBia;

            for (int i = 0; i < numberOfSach; i++)
            {
                // Xử lý ảnh bìa
                var file = post_AnhBia[i];
                if (ModelState.IsValid)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var path = Path.Combine(Server.MapPath("~/Content/images/Sach_image"),
                                        System.IO.Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        //var fileInfo = new FileInfo(file.FileName);
                        //file.SaveAs(Server.MapPath("~/Content/Upload/" + fileInfo));
                    }
                }

                if(file != null) { Path_AnhBia = file.FileName; }
                else { Path_AnhBia = ""; }

                // Insert
                dao.Update_Sach(null, TenSach[i], Convert.ToDecimal(GiaBan[i]), MoTa[i], Path_AnhBia, Convert.ToInt32(SoLuong[i]), NXB[i], listTacGia[i], listTheLoai[i]);
            }

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            int pagesize = 8;
            int pageNumber = pagesize;

            if (Session["Admin_Index_page"] != null) { pageNumber = Convert.ToInt32(Session["Admin_Index_page"]); }

            return View("Index", dao.listSach_Admin(pageNumber, pagesize));
        }

        public ActionResult Edit(int id)
        {
            AdminDAO dao = new AdminDAO();
            ViewBag.Sach_Info = dao.ChiTietSach(id);

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            return View();
        }
        [HttpPost]
        public ActionResult Edit(string MaSach, string TenSach, string GiaBan, string MoTa, string SoLuong, string listTacGia, string listTheLoai, string NXB, HttpPostedFileBase AnhBia, string image_action)
        {
            AdminDAO dao = new AdminDAO();

            int maSach = Convert.ToInt32(MaSach);

            string Path_AnhBia = "";
            var file = AnhBia;
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/images/Sach_image"),
                                    System.IO.Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    Path_AnhBia = file.FileName;
                    //var fileInfo = new FileInfo(file.FileName);
                    //file.SaveAs(Server.MapPath("~/Content/Upload/" + fileInfo));
                }
                else
                {
                    if(image_action == "KeepImage")
                    {
                        Path_AnhBia = dao.ChiTietSach(maSach).AnhBia;
                    }
                }
            }

            dao.Update_Sach(maSach, TenSach, Convert.ToDecimal(GiaBan), MoTa, Path_AnhBia, Convert.ToInt32(SoLuong), NXB, listTacGia, listTheLoai);

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            int pagesize = 8;
            int pageNumber = 1;

            if (Session["Admin_Index_page"] != null) { pageNumber = Convert.ToInt32(Session["Admin_Index_page"]); }

            return View("Index", dao.listSach_Admin(pageNumber, pagesize));
        }
        public ActionResult Delete(int id)
        {
            AdminDAO dao = new AdminDAO();

            db = new Model1();
            if (db.Sach.SingleOrDefault(n => n.MaSach == id) != null)
            {
                dao.Delete_Sach(id);
            }

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            int pagesize = 8;
            int pageNumber = 1;

            if (Session["Admin_Index_page"] != null) { pageNumber = Convert.ToInt32(Session["Admin_Index_page"]); }

            return View("Index", dao.listSach_Admin(pageNumber, pagesize));
        }
        //[HttpPost]
        public ActionResult Search(int? page, string TenSach, string Min, string Max, string TheLoai, string TacGia, string NXB)
        {
            AdminDAO dao = new AdminDAO();

            if(TenSach != null) { Session["TimTenSach"] = TenSach; }

            if (Min != null)
            {
                if (Int32.TryParse(Min, out int a) == false) { Min = ""; }
                Session["TimGiaTienMin"] = Min;
            }

            if (Max != null)
            {
                if (Int32.TryParse(Max, out int b) == false) { Max = ""; }
                Session["TimGiaTienMax"] = Max;
            }

            if (TheLoai != null)
            {
                if (TheLoai == "Tất cả") { TheLoai = ""; }
                Session["TimTheLoai"] = TheLoai;
            }

            if (TacGia != null)
            {
                if (TacGia == "Tất cả") { TacGia = ""; }
                Session["TimTacGia"] = TacGia;
            }

            if (NXB != null)
            {
                if (NXB == "Tất cả") { NXB = ""; }
                Session["TimNXB"] = NXB;
            }

            if(TenSach == "" && Min == "" && Max == "" && TheLoai == "" && TacGia == "" && NXB == "") { return RedirectToAction("Index"); }

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            Session["Controller"] = "Admin";
            Session["Action"] = "Search";
            Session["Admin_Index_page"] = page;

            int pagesize = 8;
            int pageNumber = 1;

            if(page != null)
            {
                pageNumber = Convert.ToInt32(page);
                return View("Index", dao.listSach_Admin_TimKiem(pageNumber, pagesize, Session["TimTenSach"].ToString(), Session["TimGiaTienMin"].ToString(), Session["TimGiaTienMax"].ToString(), Session["TimTheLoai"].ToString(), Session["TimTacGia"].ToString(), Session["TimNXB"].ToString()));
            }

            return View("Index", dao.listSach_Admin_TimKiem(pageNumber, pagesize, TenSach, Min, Max, TheLoai, TacGia, NXB));
        }

    }
}