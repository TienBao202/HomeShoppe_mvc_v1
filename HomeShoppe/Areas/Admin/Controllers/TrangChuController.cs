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
    public class TrangChuController : BaseController
    {
        // GET: Admin/TrangChu
        public ActionResult Index()
        {
            var userdao = new UserDAO();
            var productdao = new ProductDAO();

            ViewBag.TotalUser = userdao.Usercount();
            ViewBag.Admin = userdao.UsercountAdmin();
            ViewBag.Empploye = userdao.UsercountEmpployee();
            ViewBag.Member = userdao.UsercountMember();
            ViewBag.TotalProduct = productdao.ProductCount();

            return View();
        }
    }
}