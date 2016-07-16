using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jx.Web.Core
{
    public class VideoClient
    {
        private string token;
        private bool beginLoad = false;
        private bool completeLoad = false;
        private DateTime updateTime = DateTime.Now;
        private List<string> videoRequest = new List<string>();
        private int validTimeSeconds = 5 * 60;
        private string browser;
        private string ip;

        public string Token
        {
            get { return token; }
            set { token = value; }
        }

        public bool BeginLoad
        {
            get { return beginLoad; }
            set { beginLoad = value; }
        }

        public bool CompleteLoad
        {
            get { return completeLoad; }
            set { completeLoad = value; }
        }

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; this.beginLoad = true; }
        }


        public List<string> VideoRequest
        {
            get { return videoRequest; }
            set { videoRequest = value; }
        }

        public void addVideoRequest(string request)
        {
            videoRequest.Add(request);
            if ((browser == "chrome" && videoRequest.Count > 3) || (videoRequest.Count > 4))
            {
                this.beginLoad = true;
            }
        }

        public bool isActive()
        {
            if (beginLoad)
            {
                TimeSpan timeSpan = DateTime.Now - this.updateTime;
                if (timeSpan.Seconds > validTimeSeconds)
                {
                    completeLoad = true;
                }
            }
            return beginLoad && !completeLoad;
        }

        public bool isValidForFirstRequest()
        {
            if (browser == "internetexplorer" || browser == "ie")
            {
                return videoRequest.Count < 2;
            }
            else if (browser == "firefox")
            {
                return videoRequest.Count < 20;
            }
            else
            {
                return videoRequest.Count < 1;
            }
        }

        public string Browser
        {
            get { return browser; }
            set { browser = value; }
        }

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }
    }


}