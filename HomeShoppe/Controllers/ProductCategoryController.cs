using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;


namespace HomeShoppe.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ViewCategory();
            return PartialView(model);
        }

        public PartialViewResult DanhMucTrangChu()
        {
            var model = new ProductCategoryDAO().ViewCategory();
            return PartialView(model);
        }

        public PartialViewResult DanhMucThuNho()
        {
            var model = new ProductCategoryDAO().ViewCategory();
            return PartialView(model);
        }
    }
}