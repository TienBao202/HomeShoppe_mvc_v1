using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using Common;
using Model.CustomModel;
using BotDetect.Web.Mvc;

namespace HomeShoppe.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var res = dao.Login(model.UserName, PasswordEncryptor.MD5Hash(model.Password));

                if (res == 1)
                {
                    var user = dao.KiemTraDangNhap(model.UserName);
                    var userSession = new LoginDetail();

                    userSession.UserName = user.UserName;
                    userSession.User = user;
                    userSession.GroupID = user.GroupID;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (res == 0)
                    {
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    }
                    if (res == 2)
                    {
                        ModelState.AddModelError("", "Mật khẩu không chính xác");
                    }
                    if (res == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản đã bị khóa");
                    }
                    
                }
            }
            return View(model);
        }

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [SimpleCaptchaValidation("CaptchaCode", "registerCapcha", "Mã xác nhận không đúng!")]
        public ActionResult DangKy(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userdao = new UserDAO();
                if (userdao.CheckUserName(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (userdao.CheckEmail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    user.UserName = model.UserName;
                    user.Password = PasswordEncryptor.MD5Hash( model.Password );
                    user.Name = model.FullName;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    user.GroupID = "MEMBER";

                    var result = userdao.Insert(user);
                    if ( result > 0)
                    {
                        ViewBag.success = "Đăng ký thành công";
                        model = new RegisterViewModel();
                        
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký không thành công");
                    }
                
                }
            }
            return View(model); 
        }

        public ActionResult DangXuat()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }

        public ActionResult ThongTinKhachHang(string yeucau)
        {

            var productdao = new ProductDAO();
            ViewBag.XemNhieuNhat = productdao.XemNhieuNhat();

            var userdao = new UserDAO();
            var session = (Common.LoginDetail)Session[Common.CommonConstants.USER_SESSION];
            var model = userdao.GetByID(session.User.ID);

            return View(model);
        }
        [HttpPost]
        public ActionResult ThongTinKhachHang(User entity)
        {
            var session = (Common.LoginDetail)Session[Common.CommonConstants.USER_SESSION];
            entity.Status = true;
            entity.GroupID = "MEMBER";
            entity.Password = session.User.Password;
            if (!ModelState.IsValid)
            {
                var dao = new UserDAO();

                var result = dao.Update(entity);
                if (result)
                {
                    ViewBag.ThanhCong = "Cập nhật thông tin người dùng thành công";
                    var productdao = new ProductDAO();
                    ViewBag.XemNhieuNhat = productdao.XemNhieuNhat();
                }
                else
                {
                    ViewBag.ThatBai = "Cập nhật thông tin người dùng không thành công";
                }
            }
            return View(entity);
        }
        public ActionResult ThongTinDonHang()
        {
            var session = (Common.LoginDetail)Session[Common.CommonConstants.USER_SESSION];

            var productdao = new ProductDAO();
            ViewBag.XemNhieuNhat = productdao.XemNhieuNhat();
           
            var orderdao = new OrderDAO();
            var vieworder  = orderdao.ViewOrderByCustomerID(session.User.ID);
            ViewBag.ViewOrder = vieworder;

            var orderdetaildao = new OrderDetailDAO();
            var list = orderdetaildao.List(vieworder.ID);

            return View(list);
        }

    }
}