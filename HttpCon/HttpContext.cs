using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OhHttp.HttpCon
{
    internal class HttpContext
    {
        public string url;
        public HttpContext(string _url)
        {
            url = _url;
        }

        public string HttpGet()
        {
            using WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string result= wc.DownloadString(url);
            return result;
        }
    }
}
