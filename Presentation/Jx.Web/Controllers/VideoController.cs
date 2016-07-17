using Jx.Web.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jx.Web.Controllers
{
    public class VideoController : Controller
    {
        //public ActionResult GetVideo(String category, String name)
        //{
        //    if (name.IndexOf(".") == -1)
        //        name += ".mp4";
        //    var path = Server.MapPath("~/Content/Video/" + category + "/" + name);
        //    return File(path, "video/mp4", Url.Encode(name));
        //}

        public ActionResult VideoPage(string name)
        {
            //System.Web.HttpContext.Current.Request.ip
            string token = Guid.NewGuid().ToString();
            string browser = Request.Browser.Browser.ToLower().Trim();
            string ip = Request.UserHostAddress;
            VideoClientsManage.addClient(token, browser, ip);
            if (VideoClientsManage.isClientFull())
            {
                return View("OnlineFull");
            }
            else
            {
                this.ViewData["token"] = token;
                this.ViewData["name"] = name.Replace("_", "/");
                return View();
            }
        }

        public ActionResult OnlineFull()
        {
            return View();
        }

        public ActionResult NotifyLoading(string token)
        {
            string browser = Request.Browser.Browser.ToLower().Trim();
            VideoClientsManage.notifyLoading(token, browser);
            return new EmptyResult();
        }

        public ActionResult NotifyLoadCompleted(string token)
        {
            string browser = Request.Browser.Browser.ToLower().Trim();
            VideoClientsManage.notifyCompleteLoad(token, browser);
            return new EmptyResult();
        }

        public ActionResult ClientsBroad(string p)
        {
            if (p == "jx2016")
            {
                this.ViewData["TotalNumber"] = VideoClientsManage.getTotalCount();
                this.ViewData["NoLoadingNumber"] = VideoClientsManage.getNoLoadingCount();
                this.ViewData["LoadingNumber"] = VideoClientsManage.getActiveCount();
                this.ViewData["CompletedLoadNumber"] = VideoClientsManage.getCompletedLoadCount();
                return View();
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}