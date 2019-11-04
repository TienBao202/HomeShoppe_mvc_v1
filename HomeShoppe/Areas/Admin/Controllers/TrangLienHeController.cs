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
    public class TrangLienHeController : BaseController
    {
        // GET: Admin/TrangLienHe
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new ContactDAO();
            var listContact = dao.ListAll(searchString, page, pagesize);
            return View(listContact);
        }

        // Xử lý 
        [HttpGet]
        public ActionResult ChiTiet(string ID)
        {
            var dao = new ContactDAO();
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
        public ActionResult ThemMoi(Contact entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDAO();

                var result = dao.Insert(entity);
                if (result)
                {
                    SetAlert("Thêm liên hệ thành công", "success");
                    return RedirectToAction("Index", "TrangLienHe");
                }
                else
                {
                    SetAlert("Thêm liên hệ không thành công", "error");
                    return RedirectToAction("ThemMoi", "TrangLienHe");

                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(string ID)
        {
            var model = new ContactDAO().GetByID(ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Contact entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContactDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật liên hệ thành công", "success");
                    return RedirectToAction("Index", "TrangLienHe");
                }
                else
                {
                    SetAlert("Cập nhật liên hệ không thành công", "error");
                    return RedirectToAction("CapNhat", "TrangLienHe");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(string ID)
        {
            var model = new ContactDAO().GetByID(ID);

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
            var result = new ContactDAO().Delete(ID);
            SetAlert("Xóa thông tin  thành công", "success");
            return RedirectToAction("Index", "TrangLienHe");
        }
    }
}