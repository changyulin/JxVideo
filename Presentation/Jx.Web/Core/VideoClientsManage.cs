using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jx.Web.Core
{
    public class VideoClientsManage
    {
        private static object obj = new object();
        private static Dictionary<string, VideoClient> clients = new Dictionary<string, VideoClient>();
        private static int limitCount = 20;

        static VideoClientsManage()
        {

        }

        public static void addClient(string token, string browser, string ip)
        {
            lock (obj)
            {
                VideoClient client = new VideoClient();
                client.Token = token;
                client.Browser = browser;
                client.Ip = ip;
                clients.Add(token, client);
            }
        }

        public static void addVideoRequest(string token, string data)
        {
            lock (obj)
            {
                clients[token].addVideoRequest(data);
            }
        }

        public static bool isValidForFirstRequest(string token)
        {
            return clients[token].isValidForFirstRequest();
        }

        public static bool isClientFull()
        {
            return getActiveCount() >= limitCount;
        }

        public static bool exist(string token, string browser)
        {
            return clients.Values.Where(t => t.Token == token && t.Browser == browser).Any();
        }

        public static int getActiveCount()
        {
            return clients.Values.Where(c => c.isActive()).Count();
        }

        public static int getTotalCount()
        {
            return clients.Count();
        }

        public static int getNoLoadingCount()
        {
            return clients.Values.Where(c => c.BeginLoad == false).Count();
        }

        public static int getCompletedLoadCount()
        {
            return clients.Values.Where(c => c.CompleteLoad == true).Count();
        }

        public static void notifyLoading(string token, string browser)
        {
            lock (obj)
            {
                if (exist(token, browser))
                {
                    clients[token].UpdateTime = DateTime.Now;
                }
            }
        }

        public static void notifyCompleteLoad(string token, string browser)
        {
            lock (obj)
            {
                if (exist(token, browser))
                {
                    clients[token].CompleteLoad = true;
                }
            }
        }
    }
}