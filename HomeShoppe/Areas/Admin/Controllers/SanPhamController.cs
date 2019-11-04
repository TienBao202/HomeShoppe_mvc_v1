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

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/SanPham
        public ActionResult Index(string searchString, int categoryid = 0, int page = 1, int pagesize = 5)
        {
            var dao = new ProductDAO();
            var list = dao.ListAllByCategoryID( categoryid,searchString, page, pagesize);
            DropdownProductCategory();
            DropdownCategory();
            return View(list);
        }
        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var dao = new ProductDAO();
            var model = dao.GetByID(ID);
            ViewBag.price = model.Price.HasValue ? model.Price.Value.ToString(" 0,0 vnđ") : "";
            ViewBag.PromotionPrice = model.PromotionPrice.HasValue ? model.PromotionPrice.Value.ToString(" 0,0 vnđ") : "";
            if (model.Status == true)
            {
                ViewBag.status = "Đang kinh doanh sản phẩm này.";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Sản phẩm này đã ngừng kinh doanh.";
                ViewBag.status_class = "bg-red";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            DropdownCategory();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(Product entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();

                long id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    SetAlert("Thêm sản phẩm không thành công", "error");
                    return RedirectToAction("ThemMoi", "SanPham");

                }
            }
            DropdownCategory();
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(int ID)
        {
            var model = new ProductDAO().GetByID(ID);
            DropdownCategory(model.CategoryID);

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(Product entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();  
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật thông tin sản phẩm thành công", "success");
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    SetAlert("Cập nhật thông tin sản phẩm không thành công", "error");
                    return RedirectToAction("CapNhat", "SanPham");
                }
            }
            DropdownCategory(entity.CategoryID);
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int ID)
        {
            var model = new ProductDAO().GetByID(ID);

            ViewBag.price = model.Price.HasValue ? model.Price.Value.ToString(" 0,0 vnđ") : "";
            ViewBag.PromotionPrice = model.PromotionPrice.HasValue ? model.PromotionPrice.Value.ToString(" 0,0 vnđ") : "";
            if (model.Status == true)
            {
                ViewBag.status = "Đang kinh doanh sản phẩm này.";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Sản phẩm này đã ngừng kinh doanh.";
                ViewBag.status_class = "bg-red";
            }


            return View(model);
        }
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult xacnhanxoa(int ID)
        {
            var result = new ProductDAO().Delete(ID);
            SetAlert("Xóa thông tin sản phẩm thành công", "success");
            return RedirectToAction("Index", "SanPham");
        }

        public void DropdownProductCategory(int? CategoryID = null )
        {
            var dao = new ProductCategoryDAO();
            ViewBag.ProductCategoryList = new SelectList(dao.ListParentCategory(), "ID", "Name", CategoryID);
        }
        public void DropdownCategory(int? CategoryID = null)
        {
            var dao = new ProductCategoryDAO();
            ViewBag.CategoryList = new SelectList(dao.GetCategoriesSelectList(), "ID", "Name", CategoryID);
        }

    }
}