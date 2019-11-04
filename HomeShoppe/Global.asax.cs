using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Data;

namespace HomeShoppe
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Application["HomNay"] = 0;
            //Application["HomQua"] = 0;
            //Application["TuanNay"] = 0;
            //Application["TuanTruoc"] = 0;
            //Application["ThangNay"] = 0;
            //Application["ThangTruoc"] = 0;
            //Application["TatCa"] = 0;
            //Application["visitors_online"] = 0;
            if (!File.Exists(Server.MapPath("~") + @"\Count_Visited.txt"))
                File.WriteAllText(Server.MapPath("~") + @"\Count_Visited.txt", "0");
            Application["DaTruyNhap"] = int.Parse(File.ReadAllText(Server.MapPath("~") + @"\Count_Visited.txt"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Application["DangTruyNhap"] == null)
                Application["DangTruyNhap"] = 1;
            else
                Application["DangTruyNhap"] = (int)Application["DangTruyNhap"] + 1;
            Application["DaTruyNhap"] = (int)Application["DaTruyNhap"] + 1;
            File.WriteAllText(Server.MapPath("~") + @"\Count_Visited.txt", Application["DaTruyNhap"].ToString());

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application["DangTruyNhap"] = (int)Application["DangTruyNhap"] - 1;
        }

        //void Application_End(object sender, EventArgs e)
        //{
        //    // Code that runs on application shutdown
        //}
        //void Application_Error(object sender, EventArgs e)
        //{
        //    // Code that runs when an unhandled error occurs
        //}
        //void Session_Start(object sender, EventArgs e)
        //{
        //    Session.Timeout = 150;
        //    Application.Lock();
        //    Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
        //    Application.UnLock();
        //    try
        //    {
        //        DataBindSQL webseoazThongKe = new DataBindSQL();
        //        DataTable dtb = webseoazThongKe.TableEGThongKe();
        //        if (dtb.Rows.Count > 0)
        //        {
        //            Application["HomNay"] = long.Parse("0" + dtb.Rows[0]["HomNay"]).ToString("#,###");
        //            Application["HomQua"] = long.Parse("0" + dtb.Rows[0]["HomQua"]).ToString("#,###");
        //            Application["TuanNay"] = long.Parse("0" + dtb.Rows[0]["TuanNay"]).ToString("#,###");
        //            Application["TuanTruoc"] = long.Parse("0" + dtb.Rows[0]["TuanTruoc"]).ToString("#,###");
        //            Application["ThangNay"] = long.Parse("0" + dtb.Rows[0]["ThangNay"]).ToString("#,###");
        //            Application["ThangTruoc"] = long.Parse("0" + dtb.Rows[0]["ThangTruoc"]).ToString("#,###");
        //            Application["TatCa"] = long.Parse("0" + dtb.Rows[0]["TatCa"]).ToString("#,###");
        //        }
        //        dtb.Dispose();
        //        webseoazThongKe = null;
        //    }
        //    catch { }
        //}
        //void Session_End(object sender, EventArgs e)
        //{
        //    Application.Lock();
        //    Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
        //    Application.UnLock();
        //}

        //private class DataBindSQL
        //{
        //    internal DataTable TableEGThongKe()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}

