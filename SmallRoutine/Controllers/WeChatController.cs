using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace SmallRoutine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeChatController: ControllerBase
    {
        private readonly IWeChatHttpClientService  _weChatHttpClient;

        public WeChatController(IWeChatHttpClientService  weChatHttpClient)
        {
            this._weChatHttpClient = weChatHttpClient;
        }

        /// <summary>
        ///  (小程序端接口)  根据 code   等信息获取用户基本信息
        /// </summary>
        [HttpPost("/GetOpenid")]
        public ActionResult<WeChatInfoModel> GetWeChartUserInfo(WeChatCodeModel codeModel)
        {
            WeChatInfoModel resModel = _weChatHttpClient.GetWeChartUserInfo(codeModel);
            return resModel;
        }


        /// <summary>
        ///  (小程序端接口)  根据 code,iv,encryptedData   等信息获取用户基本信息
        /// </summary>
        [HttpPost("/GetOpenidAndUnionid")]
        public ActionResult<WechatUserInfo> GetWeChartUserInfoNew(WeChatUserModel  weChatUser)
        {
            WechatUserInfo resModel = _weChatHttpClient.GetWeChartUserInfoNew(weChatUser);
            return resModel;
        }


        /// <summary>
        ///  (小程序端接口)  根据 登录用户名判断是否已经绑定该微信接收消息推送
        ///  /// </summary>
        [HttpPost("/CheckBindOpenid")]
        public ActionResult<BaseViewModel> CheckBindMsg(LoginViewModel  loginView)
        {
            BaseViewModel resModel = _weChatHttpClient.CheckBindMsg(loginView);
            return resModel;
        }


        /// <summary>
        ///  (小程序端接口)  根据 登录用户名判断是否已经绑定该微信接收消息推送
        ///  /// </summary>
        [HttpPost("/SaveBindOpenid")]
        public ActionResult<BaseViewModel> SaveBindMsg(BindMsgModel  bindMsg)
        {
            BaseViewModel resModel = _weChatHttpClient.SaveBindMsg(bindMsg);
            return resModel;
        }

    }
}
