using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Common;
using PagedList;
using System.Globalization;
using System.Web.Mvc.Ajax;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new FooterDAO();
            var listFooter = dao.ListAll(searchString, page, pagesize);
            return View(listFooter);
        }
        // Xử lý 
        [HttpGet]
        public ActionResult ChiTiet(string ID)
        {
            var dao = new FooterDAO();
            var model = dao.GetByID(ID);
            if (model.Status == true)
            {
                ViewBag.status = "Đang sử dụng";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Khóa";
                ViewBag.status_class = "bg-red";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(Footer entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDAO();

                var result = dao.Insert(entity);
                if (result)
                {
                    SetAlert("Thêm kiểu footer thành công", "success");
                    return RedirectToAction("Index", "Footer");
                }
                else
                {
                    SetAlert("Thêm kiểu footer không thành công", "error");
                    return RedirectToAction("ThemMoi", "Footer");

                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(string ID)
        {
            var model = new FooterDAO().GetByID(ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Footer entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new FooterDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật kiểu footer thành công", "success");
                    return RedirectToAction("Index", "Footer");
                }
                else
                {
                    SetAlert("Cập nhật kiểu footer không thành công", "error");
                    return RedirectToAction("CapNhat", "Footer");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(string ID)
        {
            var model = new FooterDAO().GetByID(ID);

            if (model.Status == true)
            {
                ViewBag.status = "Đang sử dụng";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Đã khóa";
                ViewBag.status_class = "bg-red";
            }
            return View(model);
        }
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult xacnhanxoa(string ID)
        {
            var result = new FooterDAO().Delete(ID);
            SetAlert("Xóa thông tin  thành công", "success");
            return RedirectToAction("Index", "Footer");
        }

    }
}