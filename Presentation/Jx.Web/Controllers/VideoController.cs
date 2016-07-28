using Jx.Core;
using Jx.Core.Domain.Customers;
using Jx.Core.Domain.Security;
using Jx.Services.Security;
using Jx.Web.Core;
using Jx.Web.Models;
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
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;
        private readonly IPermissionService _permissionService;


        public VideoController(HttpContextBase httpContext,
            IWorkContext workContext,
            IPermissionService permissionService)
        {
            this._httpContext = httpContext;
            this._workContext = workContext;
            this._permissionService = permissionService;
        }

        public ActionResult VideoPage(string name, string inIframe)
        {
            PermissionRecord pr = this._permissionService.GetPermissionRecordBySystemName(name);
            if (pr != null)
            {
                Customer customer = _workContext.CurrentCustomer;
                if (customer.IsGuest())
                {
                    if (inIframe == "1")
                    {
                        MessageViewModel messageViewModel = new MessageViewModel();
                        messageViewModel.Message = "观看此视频需要先登录！";
                        return View("MessagePage", messageViewModel);
                    }
                    else
                    {
                        //this._httpContext.Request.Url.Host
                        return Redirect("http://localhost/login?returnUrl=http://localhost:8080/Video/name");
                    }
                }
                else if (!this._permissionService.Authorize(pr))
                {
                    MessageViewModel messageViewModel = new MessageViewModel();
                    messageViewModel.Message = "您的账号信息中没有填写剑学编码，所以您没有权限观看此视频！";
                    return View("MessagePage", messageViewModel);
                }
            }
            //System.Web.HttpContext.Current.Request.ip
            string token = Guid.NewGuid().ToString();
            string browser = Request.Browser.Browser.ToLower().Trim();
            string ip = Request.UserHostAddress;
            VideoClientsManage.addClient(token, browser, ip);
            if (VideoClientsManage.isClientFull())
            {
                MessageViewModel messageViewModel = new MessageViewModel();
                messageViewModel.Message = "观看的人太多了！排队中...";
                return View("MessagePage", messageViewModel);
            }
            else
            {
                this.ViewData["token"] = token;
                this.ViewData["name"] = name.Replace("_", "/");
                return View();
            }
        }

        public ActionResult MessagePage()
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