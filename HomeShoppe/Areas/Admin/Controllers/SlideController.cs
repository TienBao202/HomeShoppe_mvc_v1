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
    public class SlideController : BaseController
    {
        // GET: Admin/Slide
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new SlideDAO();
            var listslide = dao.ListAll(searchString, page, pagesize);
            return View(listslide);
        }
        // Xử lý 
        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var dao = new SlideDAO();
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
        public ActionResult ThemMoi(Slide entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();

                long id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Thêm hình ảnh thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Thêm hình ảnh không thành công", "error");
                    return RedirectToAction("ThemMoi", "Slide");

                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(int ID)
        {
            var model = new SlideDAO().GetByID(ID);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Slide entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new SlideDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật hình ảnh thành công", "success");
                    return RedirectToAction("Index", "Slide");
                }
                else
                {
                    SetAlert("Cập nhật hình ảnh không thành công", "error");
                    return RedirectToAction("CapNhat", "Slide");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int ID)
        {
            var model = new SlideDAO().GetByID(ID);

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
            var result = new SlideDAO().Delete(ID);
            SetAlert("Xóa thông tin  thành công", "success");
            return RedirectToAction("Index", "Slide");
        }
    }
}