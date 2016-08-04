using Jx.Web.Core;
using System;
using System.Collections.Generic;
using System.Web;

namespace Jx.Web.Modules
{
    public class VideoModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此模块
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
            context.EndRequest += context_EndRequest;
            context.RequestCompleted += context_RequestCompleted;
        }

        void context_RequestCompleted(object sender, EventArgs e)
        {

        }

        void context_EndRequest(object sender, EventArgs e)
        {

        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.ToString();
            if (url.IndexOf(".mp4") > -1 &&
                !existInPublicVideoList(url))
            {
                string token = HttpContext.Current.Request.Params["token"];
                string browser = HttpContext.Current.Request.Browser.Browser.ToLower().Trim();
                string range = HttpContext.Current.Request.Headers["Range"];
                if (VideoClientsManage.exist(token, browser))
                {
                    if (browser == "internetexplorer" || browser == "ie")
                    {
                        if (string.IsNullOrEmpty(range) && !VideoClientsManage.isValidForFirstRequest(token))
                        {
                            HttpContext.Current.RewritePath("~/MessagePage");
                            return;
                        }
                        VideoClientsManage.addVideoRequest(token, range);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(range) || (range.StartsWith("bytes=0-") && !VideoClientsManage.isValidForFirstRequest(token)))
                        {
                            HttpContext.Current.RewritePath("~/MessagePage");
                            return;
                        }
                        VideoClientsManage.addVideoRequest(token, range);
                    }
                }
                else
                {
                    HttpContext.Current.RewritePath("~/MessagePage");
                }
            }
        }

        private static string[] publicVideoList = null;

        private static string[] PublicVideoList
        {
            get
            {
                if (publicVideoList == null)
                {
                    publicVideoList = new string[] { "1234.mp4" };
                }
                return publicVideoList;
            }
        }
        private static bool existInPublicVideoList(string value)
        {
            for (int i = 0; i < PublicVideoList.Length; i++)
            {
                if (value.IndexOf(PublicVideoList[i]) > -1)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

    }
}
