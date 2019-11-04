using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeShoppe
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.IgnoreRoute("{*botdetect}",
       new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                name: "HienThiSanPham",
                url: "san-pham/{MetaTitle}-{categoryID}",
                defaults: new { controller = "Product", action = "HienThiSanPhamTheoDanhMuc", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "ChiTietSanPham",
               url: "chi-tiet/{MetaTitle}-{productID}",
               defaults: new { controller = "Product", action = "HienThiChiTietSanPham", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "Cart",
              url: "gio-hang",
              defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Add Cart",
              url: "them-gio-hang",
              defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "ThanhToan",
             url: "thanh-toan",
             defaults: new { controller = "Cart", action = "ThanhToan", id = UrlParameter.Optional }
         );
            routes.MapRoute(
             name: "HoanThanh",
             url: "hoan-thanh-thanh-toan/{orderID}",
             defaults: new { controller = "Cart", action = "HoanThanh", id = UrlParameter.Optional }
         );

            routes.MapRoute(
            name: "DangKy",
            url: "dang-ky",
            defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional }
        );

            routes.MapRoute(
             name: "DangNhap",
             url: "dang-nhap",
             defaults: new { controller = "User", action = "DangNhap", id = UrlParameter.Optional }
         );

            routes.MapRoute(
            name: "KhachHang_TaiKhoan",
            url: "khach-hang/tai-khoan",
            defaults: new { controller = "User", action = "ThongTinKhachHang", id = UrlParameter.Optional }
        );
            routes.MapRoute(
         name: "KhachHang_DonHang",
         url: "khach-hang/don-hang",
         defaults: new { controller = "User", action = "ThongTinDonHang", id = UrlParameter.Optional }
     );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
