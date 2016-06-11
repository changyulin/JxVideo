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
        public ActionResult GetVideo(String category, String name)
        {
            if (name.IndexOf(".") == -1)
                name += ".mp4";
            var path = Server.MapPath("~/Content/Video/" + category + "/" + name);
            return File(path, "video/mp4", Url.Encode(name));

            //if (name.IndexOf(".") == -1)
            //    name += ".mp4";
            //var path = Server.MapPath("~/Content/Video/" + category + "/" + name);
            //var fileStream = new FileStream(path, FileMode.Open);
            //return File(fileStream, "video/mp4", Url.Encode(name));
        }

        public ActionResult VideoPage(String name)
        {
            this.ViewData["name"] = name;
            return View();
        }
    }
}