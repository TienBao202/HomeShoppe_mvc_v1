using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace HomeShoppe.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult HienThiSanPhamTheoDanhMuc(int categoryID, string ListSortBy, string ListPrice, int page = 1, int pagesize = 6)
        {
            var productdao = new ProductDAO();
            var productcategorydao = new ProductCategoryDAO();
            

            ViewBag.CategoryDetail = productcategorydao.ViewCategoryDetail(categoryID);
            ViewBag.DanhMucCon = productcategorydao.ListChildCategory(categoryID);
            ViewBag.XemNhieuNhat = productdao.XemNhieuNhat();

            int totalRecord = 0;
            var list = productdao.DanhSachSanPham(categoryID, ListSortBy, ListPrice, ref totalRecord, page, pagesize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pagesize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;

            DropdownSortBy();
            DropdownPrice();

            return View(list);
        }

        public ActionResult HienThiChiTietSanPham(int productID)
        {
            var productdao = new ProductDAO();
            var productcategorydao = new ProductCategoryDAO();

            var productDetail = productdao.ViewProductDetail(productID);
            ViewBag.CategoryDetail = productcategorydao.ViewCategoryDetail(productDetail.CategoryID.Value);
            ViewBag.SanPhamCungLoai = productdao.SanPhamCungLoai(productID);
            return View(productDetail);
        }

        public void DropdownSortBy(string sortby = null)
        {
            List<SelectListItem> ListSortBy = new List<SelectListItem>();
            ListSortBy.Add(new SelectListItem { Text = "Tên sản phẩm từ A-Z", Value = "name-ASC" });
            ListSortBy.Add(new SelectListItem { Text = "Giá tăng dần", Value = "price-ASC" });
            ListSortBy.Add(new SelectListItem { Text = "Giá giảm dần", Value = "price-DESC" });
            ViewBag.SortByList = new SelectList(ListSortBy, "Value", "Text", sortby);
        }
        public void DropdownPrice(string price = null)
        {
            List<SelectListItem> ListPrice = new List<SelectListItem>();
            ListPrice.Add(new SelectListItem { Text = "Dưới 1 triệu", Value = "0 and 1000000" });
            ListPrice.Add(new SelectListItem { Text = "1 Triệu - 5 Triệu", Value = "1000000 and 5000000" });
            ListPrice.Add(new SelectListItem { Text = "5 Triệu - 10 Triệu", Value = "5000000 and 10000000" });
            ListPrice.Add(new SelectListItem { Text = "10 Triệu - 20 Triệu", Value = "5000000 and 10000000" });
            ListPrice.Add(new SelectListItem { Text = "Trên 20 Triệu", Value = "> 20000000" });
            ViewBag.SortByPrice = new SelectList(ListPrice, "Value", "Text", price);
        }
    }
}