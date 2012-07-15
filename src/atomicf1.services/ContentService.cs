using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using atomicf1.common;

namespace atomicf1.services
{
    public class ContentService : IContentService
    {
        private readonly IConfigurationManager _configurationManager;

        public ContentService(IConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        public string GetContent(string pageName, string args, string host)
        {
            WebRequest request = HttpWebRequest.Create(_configurationManager["ContentBaseUrl"] + pageName + args);
            if (!String.IsNullOrEmpty(host))
            {
                request.Headers.Add("x-forwarded-host", host);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            string responseData = sr.ReadToEnd();

            responseData = responseData.Replace(" href=\"/", " href=\"" + _configurationManager["ContentBaseUrl"]);
            responseData = responseData.Replace(" src=\"/", " src=\"" + _configurationManager["ContentBaseUrl"]);

            return responseData;
        }

        public string GetContentByPostback(string pageName, string data, string host)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);

            WebRequest request = HttpWebRequest.Create(_configurationManager["ContentBaseUrl"] + pageName);
            if (!String.IsNullOrEmpty(host))
            {
                request.Headers.Add("x-forwarded-host", host);
            }

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = buffer.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Flush();
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(responseStream);
            string responseData = sr.ReadToEnd();

            return responseData;
        }

        public string GetNews()
        {
            return GetContent("formula1feed.aspx", "", "");
        }
    }
}
