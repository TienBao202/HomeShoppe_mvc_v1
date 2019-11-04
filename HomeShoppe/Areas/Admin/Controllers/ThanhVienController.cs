using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Common;
using PagedList;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class ThanhVienController : BaseController
    {
        // GET: Admin/QLThanhVien
        public ActionResult Index(string usergroupid, string searchString, int page = 1, int pagesize = 10)
        {
            var userdao = new UserDAO();
            int totalRecord = 0;
            var list = userdao.ListAll(usergroupid, searchString, ref totalRecord, page, pagesize);

            //ViewBag.searchString = searchString;
            //ViewBag.Total = totalRecord;
            //ViewBag.Page = page;

            //int maxPage = 5;
            //int totalPage = 0;

            //totalPage = (int)Math.Ceiling((double)(totalRecord / pagesize));
            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = totalPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            DropdownUsergroup();
            return View(list);
        }
        [HttpGet]
        public ActionResult ChiTiet(int ID)
        {
            var dao = new UserDAO();
            var model = dao.GetByID(ID);
            ViewBag.Birthday = model.Birthday.HasValue ? model.Birthday.Value.ToString("dd/MM/yyyy") : "";
            if (model.Status == true)
            {
                ViewBag.status = "Tài khoản đang hoạt động";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Tài khoản đã bị khóa";
                ViewBag.status_class = "bg-red";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            DropdownUsergroup();
            DropdownGender();
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(User entity)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();

                var encryptedMd5Pas = PasswordEncryptor.MD5Hash(entity.Password);
                entity.Password = encryptedMd5Pas;

                if (dao.CheckUserName(entity.UserName))
                {
                    SetAlert("Tên đăng nhập đã tồn tại", "warning");
                    return RedirectToAction("ThemMoi", "ThanhVien");
                }
                else
                {
                    long id = dao.Insert(entity);
                    if (id > 0)
                    {
                        SetAlert("Thêm thông tin người dùng thành công", "success");
                        return RedirectToAction("Index", "ThanhVien");
                    }
                    else
                    {
                        SetAlert("Thêm nhân viên không thành công", "error");
                        return RedirectToAction("ThemMoi", "ThanhVien");

                    }
                }
            }
            DropdownUsergroup();
            DropdownGender();
            return View("Index");
        }
        [HttpGet]
        public ActionResult CapNhat(int ID)
        {
            var model = new UserDAO().GetByID(ID);
            DropdownUsergroup(model.GroupID);
            DropdownGender(model.Gender);

            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(User entity)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDAO();

                var encryptedMd5Pas = PasswordEncryptor.MD5Hash(entity.Password);
                entity.Password = encryptedMd5Pas;

                var result = dao.Update(entity);
                if (result)
                {
                    SetAlert("Cập nhật thông tin người dùng thành công", "success");
                    return RedirectToAction("Index", "ThanhVien");
                }
                else
                {
                    SetAlert("Cập nhật thông tin người dùng không thành công", "error");
                    return RedirectToAction("CapNhat", "ThanhVien");
                }
            }
            DropdownUsergroup(entity.GroupID);
            DropdownGender(entity.Gender);
            return View("Index");
        }
        [HttpGet]
        public ActionResult Xoa(int ID)
        {
            var model = new UserDAO().GetByID(ID);

            ViewBag.Birthday = model.Birthday.HasValue ? model.Birthday.Value.ToString("dd/MM/yyyy") : "";
            if (model.Status == true)
            {
                ViewBag.status = "Tài khoản đang hoạt động";
                ViewBag.status_class = "bg-green";
            }
            else
            {
                ViewBag.status = "Tài khoản đã bị khóa";
                ViewBag.status_class = "bg-red";
            }


            return View(model);
        }
        [HttpPost, ActionName("Xoa")]
        [ValidateAntiForgeryToken]
        public ActionResult xacnhanxoa(int ID)
        {
            var result = new UserDAO().Delete(ID);
            SetAlert("Xóa thông tin người dùng thành công", "success");
            return RedirectToAction("Index", "ThanhVien");
        }

        public void DropdownGender(string gender = null)
        {
            List<string> ListGender = new List<string>() { "Nam", "Nữ" };
            ViewBag.GenderList = new SelectList(ListGender, gender);
        }
        public void DropdownUsergroup(string UsergroupID = null)
        {
            var dao = new UserGroupDAO();
            ViewBag.UserGroupList = new SelectList(dao.List(), "ID", "Name", UsergroupID);
        }
    }
}