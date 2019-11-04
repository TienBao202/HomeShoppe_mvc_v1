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
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string searchString, int menutypeID = 0, int page = 1, int pagesize = 10)
        {
            var dao = new MenuDAO();
            var listmenu = dao.ListAll(menutypeID, searchString, page, pagesize);
            DropdownMenuType();
            return View(listmenu);
        }
        public void DropdownMenuType(int? menutypeID = null)
        {
            var dao = new MenuTypeDAO();
            ViewBag.MenuTypeList = new SelectList(dao.List(), "ID", "Name", menutypeID);
        }
        public ActionResult IndexMenuType(string searchString, int page = 1, int pagesize = 10)
        {
            var dao = new MenuTypeDAO();
            var listmenutype = dao.ListAll(searchString, page, pagesize);
            return View(listmenutype);
        }

        //Xử lý Menu
        [HttpGet]
        public ActionResult ThemMoiMenu()
        {
            DropdownMenuType();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiMenu(Menu entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();

                long id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Thêm menu thành công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    SetAlert("Thêm menu không thành công", "error");
                    return RedirectToAction("ThemMoiMenu", "Menu");

                }
            }
            DropdownMenuType();
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhatMenu(int ID)
        {
            var model = new MenuDAO().GetByID(ID);
            DropdownMenuType(model.TypeID);

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhatMenu(Menu entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật menu thành công", "success");
                    return RedirectToAction("Index", "Menu");
                }
                else
                {
                    SetAlert("Cập nhật menu không thành công", "error");
                    return RedirectToAction("CapNhatMenu", "Menu");
                }
            }
            DropdownMenuType(entity.TypeID);
            return View("Index");
        }
        [HttpDelete]
        public ActionResult XoaMenu(int ID)
        {
            var result = new MenuDAO().Delete(ID);
            SetAlert("Xóa thông tin thành công", "success");
            return RedirectToAction("Index", "Menu");
        }

        //Xử lý MenuType
        [HttpGet]
        public ActionResult ThemMoiMenuType()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoiMenuType(MenuType entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDAO();

                long id = dao.Insert(entity);
                if (id > 0)
                {
                    SetAlert("Thêm loại menu thành công", "success");
                    return RedirectToAction("IndexMenutype", "Menu");
                }
                else
                {
                    SetAlert("Thêm menu không thành công", "error");
                    return RedirectToAction("ThemMoiMenuType", "Menu");

                }
            }
            return View("IndexMenutype");
        }
        [HttpGet]
        public ActionResult CapNhatMenuType(int ID)
        {
            var model = new MenuTypeDAO().GetByID(ID);

            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CapNhatMenuType(MenuType entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuTypeDAO();
                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật loại menu thành công", "success");
                    return RedirectToAction("IndexMenuType", "Menu");
                }
                else
                {
                    SetAlert("Cập nhật menu không thành công", "error");
                    return RedirectToAction("CapNhatMenuType", "Menu");
                }
            }

            return View("IndexMenutype");
        }
        [HttpDelete]
        public ActionResult XoaMenuType(int ID)
        {
            var result = new MenuTypeDAO().Delete(ID);
            SetAlert("Xóa thông tin thành công", "success");
            return RedirectToAction("IndexMenutype", "Menu");
        }
    }
}