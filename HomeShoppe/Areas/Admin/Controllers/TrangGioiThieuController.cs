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
    public class TrangGioiThieuController : BaseController
    {
        // GET: Admin/TrangGioiThieu
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new AboutDAO();
            var listAbout = dao.ListAll(searchString, page, pagesize);
            return View(listAbout);
        }
        // Xử lý 
        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var dao = new AboutDAO();
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
        public ActionResult ThemMoi(About entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();

                var result = dao.Insert(entity);
                if (result)
                {
                    SetAlert("Thêm trang giới thiệu thành công", "success");
                    return RedirectToAction("Index", "TrangGioiThieu");
                }
                else
                {
                    SetAlert("Thêm trang giới thiệu không thành công", "error");
                    return RedirectToAction("ThemMoi", "TrangGioiThieu");

                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(int ID)
        {
            var model = new AboutDAO().GetByID(ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(About entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new AboutDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật trang giới thiệu thành công", "success");
                    return RedirectToAction("Index", "TrangGioiThieu");
                }
                else
                {
                    SetAlert("Cập nhật trang giới thiệu không thành công", "error");
                    return RedirectToAction("CapNhat", "TrangGioiThieu");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int ID)
        {
            var model = new AboutDAO().GetByID(ID);

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
        public ActionResult xacnhanxoa(int ID)
        {
            var result = new AboutDAO().Delete(ID);
            SetAlert("Xóa thông tin  thành công", "success");
            return RedirectToAction("Index", "TrangGioiThieu");
        }
    }
}