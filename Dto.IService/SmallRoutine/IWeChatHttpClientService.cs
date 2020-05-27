using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using ViewModel.SmallRoutine.RequestViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IWeChatHttpClientService
    {

        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        WeChatInfoModel GetWeChartUserInfo(WeChatCodeModel codeModel);

        /// <summary>
        /// 获取用户基本信息 20200525
        /// </summary>
        WechatUserInfo GetWeChartUserInfoNew(WeChatUserModel codeModel);

        /// <summary>
        /// 根据 登录用户名判断是否已经绑定该微信接收消息推送 20200523
        /// </summary>
        BaseViewModel CheckBindMsg(LoginViewModel loginView);

        /// <summary>
        /// 根据 保存绑定信息  绑定该微信接收消息推送  20200523
        /// </summary>
        BaseViewModel SaveBindMsg(BindMsgModel bindMsg);
    }
}
