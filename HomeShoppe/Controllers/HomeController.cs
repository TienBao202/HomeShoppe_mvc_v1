using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;

namespace HomeShoppe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productdao = new ProductDAO();
            var slidedao = new SlideDAO();
            var productcategorydao = new ProductCategoryDAO();

            ViewBag.slide = slidedao.List();
            ViewBag.KhuyenMaiHot = productdao.KhuyenMaiHot(4);
            ViewBag.SanPhamNoiBat = productdao.SanPhamNoiBat(4);
            ViewBag.XemNhieuNhat = productdao.XemNhieuNhat();
            ViewBag.SanPhamMoi = productdao.SanPhamMoi(4);
            ViewBag.DanhMucNoiBat = productcategorydao.Danhmucnoibat(6);
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu_nav()
        {
            var model = new MenuDAO().ListByMenuType(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu_nav()
        {
            var model = new MenuDAO().ListByMenuType(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDAO().GetFooter();
            return PartialView(model);
        }

    }
}