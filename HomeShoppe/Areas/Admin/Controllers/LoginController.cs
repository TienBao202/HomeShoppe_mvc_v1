using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using Model.DAO;
using Model.EF;
using Model.CustomModel;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, PasswordEncryptor.MD5Hash(model.Password));
                if (res == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else
                {
                    if (res == 2)
                    {
                        ModelState.AddModelError("", "Mật khẩu không chính xác");
                    }
                    if (res == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản đã bị khóa");
                    }
                    if (res == 1)
                    {
                        var user = dao.KiemTraDangNhap(model.UserName);
                        var userSession = new LoginDetail();
                        userSession.UserName = user.UserName;
                        userSession.User = user;
                        userSession.GroupID = user.GroupID;

                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "TrangChu");
                    }
                }
            }
            return View("Index");
        }
    }
}