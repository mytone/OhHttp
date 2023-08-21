using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        //module webclient get
        public string HttpGet()
        {
            using WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string result= wc.DownloadString(url);
            return result;
        }
        //module webclient post
        private string httppost()
        {
            WebClient client = new WebClient();
            
            //添加请求头
            client.Headers.Add("key", "value");  //key标头 //value标头值
            
            //创建请求体
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("key1", "value1");
            nvc.Add("key2", "value2");
            //提交数据
            var btys = client.UploadValues(url, nvc);
            //解析提交返回结果
            string str = System.Text.Encoding.UTF8.GetString(btys);
            return str;
        }


        //module httpclient
        public async Task<string> HttpClientGet()
        {
            using(HttpClient hc=new HttpClient())
            {
                var response=await hc.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string reshtml = await response.Content.ReadAsStringAsync();
                    return reshtml;
                }
                else
                {
                    return "loading...";
                }
            }          
        }


    }
}
