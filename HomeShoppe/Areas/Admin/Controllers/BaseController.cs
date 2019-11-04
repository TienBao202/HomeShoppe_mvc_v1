using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using System.Web.Routing;
using System.Web.Mvc.Ajax;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (LoginDetail)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

       

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
                TempData["AlertIcon"] = "fa fa-check";
                TempData["AlertTitle"] = "THÀNH CÔNG!";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
                TempData["AlertIcon"] = "fa fa-warning";
                TempData["AlertTitle"] = "CẢNH BÁO!";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
                TempData["AlertIcon"] = "fa fa-ban";
                TempData["AlertTitle"] = "LỖI!";
            }
            else if (type == "info")
            {
                TempData["AlertType"] = "alert-info";
                TempData["AlertIcon"] = "fa fa-info";
                TempData["AlertTitle"] = "THÔNG BÁO!";
            }
        }

       
    }
}