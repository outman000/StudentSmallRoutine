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

        /// <summary>  
        /// 根据微信小程序平台提供的解密算法解密数据  
        /// </summary>  
        /// <param name="encryptedData">加密数据</param>  
        /// <param name="iv">初始向量</param>  
        /// <param name="sessionKey">从服务端获取的SessionKey</param>  
        /// <returns></returns>  
        public   WechatUserInfo DecryptUserInfo(string encryptedData, string iv, string sessionKey)
        {
            try
            {
                WechatUserInfo userInfo;
                //创建解密器生成工具实例  
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                //设置解密器参数  
                aes.Mode = CipherMode.CBC;
                aes.BlockSize = 128;
                aes.Padding = PaddingMode.PKCS7;
                //格式化待处理字符串  
                byte[] byte_encryptedData = Convert.FromBase64String(encryptedData);
                byte[] byte_iv = Convert.FromBase64String(iv);
                byte[] byte_sessionKey = Convert.FromBase64String(sessionKey);

                aes.IV = byte_iv;
                aes.Key = byte_sessionKey;
                //根据设置好的数据生成解密器实例  
                ICryptoTransform transform = aes.CreateDecryptor();

                //解密  
                byte[] final = transform.TransformFinalBlock(byte_encryptedData, 0, byte_encryptedData.Length);

                //生成结果  
                string result = Encoding.UTF8.GetString(final);

                userInfo = JsonConvert.DeserializeObject<WechatUserInfo>(result);

                return userInfo;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
