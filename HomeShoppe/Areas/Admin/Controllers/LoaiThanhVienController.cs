using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;
using System.Web.Mvc.Ajax;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class LoaiThanhVienController : BaseController
    {
        // GET: Admin/LoaiThanhVien
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dao = new UserGroupDAO();
            var list = dao.ListAll(searchString, page, pagesize);
            return View(list);
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(UserGroup entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDAO();

                var id = dao.Insert(entity);
                if (id == true)
                {
                    SetAlert("Thêm mới thành công", "success");
                    return RedirectToAction("Index", "LoaiThanhVien");
                }
                else
                {
                    SetAlert("Thêm mới không thành công", "error");
                    return RedirectToAction("ThemMoi", "LoaiThanhVien");

                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(string ID)
        {
            var model = new UserGroupDAO().GetByID(ID);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(UserGroup entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserGroupDAO();

                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật thông tin thành công", "success");
                    return RedirectToAction("Index", "LoaiThanhVien");
                }
                else
                {
                    SetAlert("Cập nhật thông tin  không thành công", "error");
                    return RedirectToAction("CapNhat", "LoaiThanhVien");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Xoa(string ID)
        {
            var result = new UserGroupDAO().Delete(ID);
            SetAlert("Xóa thông tin thành công", "success");
            return RedirectToAction("Index", "LoaiThanhVien");
        }
      

    }
}