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
    public class DanhMucController : BaseController
    {
        // GET: Admin/DanhMuc
        public ActionResult Index(string searchString,int Parentcategoryid = 0, int page = 1, int pagesize = 10)
        {
            var dao = new ProductCategoryDAO();
            var list = dao.ListAll(Parentcategoryid, searchString, page, pagesize);
            DropdownParentCategory();
            return View(list);
        }
        public void DropdownParentCategory(int? CategoryID = null)
        {
            var dao = new ProductCategoryDAO();
            ViewBag.ParentCategoryList = new SelectList(dao.ListParentCategory(), "ID", "Name", CategoryID);
        }

        
        [HttpGet]
        public ActionResult ThemMoi()
        {
            DropdownParentCategory();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(ProductCategory entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();

                long id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "DanhMuc");
                }
                else
                {
                    SetAlert("Thêm danh mục không thành công", "error");
                    return RedirectToAction("ThemMoi", "DanhMuc");

                }
            }
             DropdownParentCategory();
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(int ID)
        {
            var model = new ProductCategoryDAO().GetByID(ID);
            DropdownParentCategory(model.ParentID);

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhat(ProductCategory entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductCategoryDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật danh mục thành công", "success");
                    return RedirectToAction("Index", "DanhMuc");
                }
                else
                {
                    SetAlert("Cập nhật danh mục không thành công", "error");
                    return RedirectToAction("CapNhat", "DanhMuc");
                }
            }
            DropdownParentCategory(entity.ParentID);
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Xoa(int ID)
        {
            var result = new ProductCategoryDAO().Delete(ID);
            SetAlert("Xóa thông tin thành công", "success");
            return RedirectToAction("Index", "DanhMuc");
        }


    }
}