using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;

namespace HomeShoppe.Areas.Admin.Controllers
{
    public class QuyenHanThanhVienController : BaseController
    {
        // GET: Admin/QuyenHanThanhVien
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dao = new RoleDAO();
            var list = dao.ListAll(searchString, page, pagesize);
            return View(list);
        }
    }
}