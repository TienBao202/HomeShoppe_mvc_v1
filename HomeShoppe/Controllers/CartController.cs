using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using Model.CustomModel;
using Common;
using System.Web.Script.Serialization;
using System.Configuration;

namespace HomeShoppe.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart


        public ActionResult Index()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<GioHangViewModel>();
            if (cart != null)
            {
                list = (List<GioHangViewModel>)cart;
            }
            return View(list);
        }

        [ChildActionOnly]
        public PartialViewResult HomeCart()
        {

            var cart = Session[CommonConstants.CartSession];
            var list = new List<GioHangViewModel>();
            if (cart != null)
            {
                list = (List<GioHangViewModel>)cart;
            }
            return PartialView(list);
        }

        //public ActionResult Home_Cart()
        //{
        //    var cart = Session[CommonConstants.CartSession];
        //    var list = new List<GioHangViewModel>();
        //    if (cart != null)
        //    {
        //        list = (List<GioHangViewModel>)cart;
        //    }
        //    return View(list);
        //}

        public ActionResult AddItem(int productid, int quantity)
        {
            var product = new ProductDAO().ViewProductDetail(productid);
            var cart = Session[CommonConstants.CartSession];
            if (cart != null)
            {
                var list = (List<GioHangViewModel>)cart;
                if (list.Exists(x => x.Product.ID == productid))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productid)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    // Tạo mới đối tượng cart item
                    var item = new GioHangViewModel();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);

                }
                // Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                // Tạo mới đối tượng cart item
                var item = new GioHangViewModel();
                item.Product = product;
                item.Quantity = quantity;

                var list = new List<GioHangViewModel>();
                list.Add(item);
                // Gán  vào session               
                Session[CommonConstants.CartSession] = list;
            }

            return RedirectToAction("Index");
        }

        public JsonResult UpdateItem(string CartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<GioHangViewModel>>(CartModel);
            var sessionCart = (List<GioHangViewModel>)Session[CommonConstants.CartSession];


            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }

            }
            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;

            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<GioHangViewModel>)Session[CommonConstants.CartSession];

            sessionCart.RemoveAll(x => x.Product.ID == id);

            Session[CommonConstants.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<GioHangViewModel>();
            if (cart != null)
            {
                list = (List<GioHangViewModel>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult ThanhToan(string shipname, string shipmobile, string shipemail, string shipaddress)
        {
            var session = (Common.LoginDetail)Session[Common.CommonConstants.USER_SESSION];

            var order = new Order();
            order.CreatedDate = DateTime.Now;
            order.ShipName = shipname;
            order.ShipMobile = shipmobile;
            order.ShipEmail = shipemail;
            order.ShipAddress = shipaddress;
            order.Status = 1;
            order.CustomerID = session.User.ID;
            try
            {
                var orderdao = new OrderDAO();
                var id = orderdao.Insert(order);

                var cart = (List<GioHangViewModel>)Session[CommonConstants.CartSession];
                var orderdetaildao = new OrderDetailDAO();
                decimal? total = 0;
                foreach (var item in cart)
                {
                    var orderdetail = new OrderDetail();
                    orderdetail.ProductID = item.Product.ID;
                    orderdetail.OrderID = (int)id;
                    orderdetail.Quantity = item.Quantity;
                    if (item.Product.PromotionPrice != null)
                    {
                        orderdetail.Price = item.Product.PromotionPrice * item.Quantity;
                        total += (item.Product.PromotionPrice.GetValueOrDefault(0) * item.Quantity);
                    }
                    else
                    {
                        orderdetail.Price = item.Product.Price * item.Quantity;
                        total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                    }

                    orderdetaildao.Insert(orderdetail);
                   
                }
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/website/template/neworder.html"));

                //content = content.Replace("{{CustomerName}}", shipname);
                //content = content.Replace("{{Phone}}", shipmobile);
                //content = content.Replace("{{Email}}", shipemail);
                //content = content.Replace("{{Address}}", shipaddress);
                //content = content.Replace("{{Total}}", total.Value.ToString("#,##0 ₫").Replace(',', '.'));

                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                //new MailHelper().SendMail(shipemail, "Đơn hàng mới từ HomeShoppe", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ HomeShoppe", content);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            Session[CommonConstants.CartSession] = null;
            return Redirect("/hoan-thanh-thanh-toan/" + order.ID);
        }

        public ActionResult HoanThanh(int orderID)
        {
            var orderdao = new OrderDAO();
            ViewBag.ViewOrder = orderdao.ViewOrder(orderID);


            var orderdetaildao = new OrderDetailDAO();
            var list = orderdetaildao.List(orderID);

            return View(list);
        }
    }
}