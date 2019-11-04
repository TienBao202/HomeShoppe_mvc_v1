using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Common;
using PagedList;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class DonHangController : BaseController
    {
        // GET: Admin/DonHang
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new OrderDAO();
            var list = dao.ListAll(searchString, page, pagesize);
            return View(list);
        }

        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var dao = new OrderDAO();
            var model = dao.GetByID(ID);
            if (model.Status == 1)
            {
                ViewBag.status = "Hoàn thành";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Đang chuyển";
                ViewBag.status_class = "bg-red";
            }
            return View(model);
        }
    }
}