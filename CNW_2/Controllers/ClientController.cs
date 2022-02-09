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
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index(int? page)
        {
            ClientDAO dao = new ClientDAO();

            if (page == null)
            {
                Session["Client_TimTenSach"] = null;
                Session["Client_TimGiaTienMin"] = null;
                Session["Client_TimGiaTienMax"] = null;
                Session["Client_TimTheLoai"] = null;
                Session["Client_TimTacGia"] = null;
                Session["Client_TimNXB"] = null;

                Session["Client_Index_page"] = null;
                Session["ClientIndex_ScrollTop"] = 0;

                Session["ClientIndex_action"] = null;
                //Session.Clear();
                //Session.Abandon();
            }

            if (page != null)
            {
                if (Session["ClientIndex_action"] == null)
                {
                    Session["ClientIndex_ScrollTop"] = 0;
                }
                else { Session["ClientIndex_action"] = null; }
            }

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            Session["Controller"] = "Client";
            Session["Action"] = "Index";
            Session["Client_Index_page"] = page;

            int pagesize = 12;
            int pageNumber = (page ?? 1);

            return View(dao.listSach_Admin(pageNumber, pagesize));
        }
        [HttpPost]
        public EmptyResult SetSession(string name, string value)
        {
            Session[name] = value;

            return null;
        }
        public ActionResult Detail(int id)
        {
            ClientDAO dao = new ClientDAO();

            Session["ClientIndex_action"] = "detail";

            ViewBag.Sach_Info = dao.ChiTietSach(id);

            return View();
        }
        public ActionResult Search(int? page, string postTenSach, string postMin, string postMax, string postTheLoai, string postTacGia, string postNXB)
        {
            if (page == null)
            {
                //Session["ClientIndex_action"] = "search";
            }

            if (page != null)
            {
                if (Session["ClientIndex_action"] == null)
                {
                    Session["ClientIndex_ScrollTop"] = 0;
                }
                else { Session["ClientIndex_action"] = null; }
            }

            ClientDAO dao = new ClientDAO();

            if (postTenSach != null) { Session["Client_TimTenSach"] = postTenSach; }

            if (postMin != null)
            {
                if (Int32.TryParse(postMin, out int a) == false) { postMin = ""; }
                Session["Client_TimGiaTienMin"] = postMin;
            }

            if (postMax != null)
            {
                if (Int32.TryParse(postMax, out int b) == false) { postMax = ""; }
                Session["Client_TimGiaTienMax"] = postMax;
            }

            if (postTheLoai != null)
            {
                if (postTheLoai == "Tất cả") { postTheLoai = ""; }
                Session["Client_TimTheLoai"] = postTheLoai;
            }

            if (postTacGia != null)
            {
                if (postTacGia == "Tất cả") { postTacGia = ""; }
                Session["Client_TimTacGia"] = postTacGia;
            }

            if (postNXB != null)
            {
                if (postNXB == "Tất cả") { postNXB = ""; }
                Session["Client_TimNXB"] = postNXB;
            }

            if (postTenSach == "" && postMin == "" && postMax == "" && postTheLoai == "" && postTacGia == "" && postNXB == "") { return RedirectToAction("Index", "Client"); }

            ViewBag.listTacGia = dao.list_TacGia();
            ViewBag.listTheLoai = dao.list_TheLoai();
            ViewBag.listNXB = dao.list_NXB();

            Session["Controller"] = "Client";
            Session["Action"] = "Search";
            Session["Client_Index_page"] = page;

            int pagesize = 12;
            int pageNumber = 1;

            if (page != null)
            {
                pageNumber = Convert.ToInt32(page);
                return View("Index", dao.listSach_Admin_TimKiem(pageNumber, pagesize, Session["Client_TimTenSach"].ToString(), Session["Client_TimGiaTienMin"].ToString(), Session["Client_TimGiaTienMax"].ToString(), Session["Client_TimTheLoai"].ToString(), Session["Client_TimTacGia"].ToString(), Session["Client_TimNXB"].ToString()));
            }

            return View("Index", dao.listSach_Admin_TimKiem(pageNumber, pagesize, postTenSach, postMin, postMax, postTheLoai, postTacGia, postNXB));
        }
    }
}