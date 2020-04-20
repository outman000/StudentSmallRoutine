using System;
using System.Collections.Generic;
using System.Text;
using Dto.IRepository.SmallRoutine;
using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace Dto.Repository.SmallRoutine
{
    public class WeChatClientRepository : IWeChatClientRepository
    {
        /// <summary>  
        /// 获取OpenId和SessionKey的Json数据包  
        /// </summary>  
        /// <param name="code">客户端发来的code</param>  
        /// <returns>Json数据包</returns>  
        public string GetOpenIdAndSessionKeyString(string code, string appId, string appSecret)
        {
            string temp = "https://api.weixin.qq.com/sns/jscode2session?" +
                "appid=" + appId
                + "&secret=" + appSecret
                + "&js_code=" + code
                + "&grant_type=authorization_code";

            return GetPage(temp);

        }

        public virtual string GetPage(string posturl)
        {

            HttpWebResponse response = null;
            HttpWebRequest request = WebRequest.Create(posturl) as HttpWebRequest;

            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.AllowAutoRedirect = true;
            request.Method = "GET";

            //发送请求并获取相应回应数据
            response = (HttpWebResponse)request.GetResponse();
            Stream instream = response.GetResponseStream();

            //返回结果网页（html）代码
            StreamReader sr = new StreamReader(instream);
            //返回结果网页（html）代码
            string content = sr.ReadToEnd();
            string err = string.Empty;
            return content;

        }

        public WeChatInfoModel Decrypt(string code, string appId, string appSecret)
        {
            if (code == null || code == "")
                return null;

            if (String.IsNullOrEmpty(code))
                return null;
            WeChatInfoModel oiask = JsonConvert.DeserializeObject<WeChatInfoModel>(GetOpenIdAndSessionKeyString(code, appId, appSecret));

            return oiask;
        }

    }
}
