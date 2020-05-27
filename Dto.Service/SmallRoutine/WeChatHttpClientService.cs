using AutoMapper;
using Dto.IRepository.SmallRoutine;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;
using Dto.IService.SmallRoutine;
using ViewModel.PublicViewModel;

namespace Dto.Service.SmallRoutine
{
    class WeChatHttpClientService: IWeChatHttpClientService
    {
 
        private readonly IWeChatClientRepository _IWeChatClientRepository;
        private readonly IMapper _IMapper;
        private IOptions<WeChartTokenMiddles> _IOptions;
        private readonly IUserInfoRepository _userInfoRepository;


        public WeChatHttpClientService(IWeChatClientRepository repository, IMapper mapper,IOptions<WeChartTokenMiddles> iOptions, IUserInfoRepository userInfo)
        {
            _IWeChatClientRepository = repository;
            _IOptions = iOptions;
            _IMapper = mapper;
            _userInfoRepository = userInfo;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        public WeChatInfoModel GetWeChartUserInfo(WeChatCodeModel codeModel)
        {
            WeChatInfoModel InfoModel = _IWeChatClientRepository.Decrypt(codeModel.code, _IOptions.Value.appid, _IOptions.Value.secret);
            return InfoModel;
        }


        /// <summary>
        /// 获取用户基本信息 20200525
        /// </summary>
        public WechatUserInfo GetWeChartUserInfoNew(WeChatUserModel   userModel)
        {
            WeChatInfoModel InfoModel = _IWeChatClientRepository.Decrypt(userModel.code, _IOptions.Value.appid, _IOptions.Value.secret);
            WechatUserInfo wechatUser = _IWeChatClientRepository.DecryptUserInfo(userModel.encryptedData, userModel.iv, InfoModel.session_key);
            return wechatUser;
        }


        /// <summary>
        /// 根据 登录用户名判断是否已经绑定该微信接收消息推送  20200523
        /// </summary>
        public BaseViewModel CheckBindMsg(LoginViewModel  loginView)
        {
            BaseViewModel InfoModel = new BaseViewModel();
            try
            {
                var info = _userInfoRepository.GetByIdnumber(loginView.Idnumber);
                //判断是否有  账号、密码信息
                if (info != null)
                {
                    //判断是否已经绑定了 微信 接收消息推送
                    if (!string.IsNullOrEmpty(info.openid) && !string.IsNullOrEmpty(info.unionid))
                    {
                        InfoModel.Message = "已绑定";
                        InfoModel.ResponseCode = 1;
                    }
                    else
                    {
                        InfoModel.Message = "未绑定";
                        InfoModel.ResponseCode = 2;
                    }
                }
                else
                {
                    InfoModel.Message = "未分配用户名";
                    InfoModel.ResponseCode = 3;
                }
            }
            catch(Exception ex)
            {
                InfoModel.Message = "出现异常";
                InfoModel.ResponseCode = 4;
            }
            
            return InfoModel;
        }


        /// <summary>
        /// 根据 保存绑定信息  绑定该微信接收消息推送  20200523
        /// </summary>
        public BaseViewModel SaveBindMsg(BindMsgModel  bindMsg)
        {
            BaseViewModel InfoModel = new BaseViewModel();
            try
            {
                var info = _userInfoRepository.GetByIdnumber(bindMsg.Idnumber);
                //判断是否有  账号、密码信息
                if (info != null)
                {
                    //判断是否已经绑定了 微信 接收消息推送
                    if (!string.IsNullOrEmpty(bindMsg.openid) && !string.IsNullOrEmpty(bindMsg.unionid))
                    {
                        info.openid = bindMsg.openid;
                        info.unionid = bindMsg.unionid;
                        info.UpdateDate = DateTime.Now;
                        _userInfoRepository.Update(info);
                        int a = _userInfoRepository.SaveChanges();
                        if (a > 0)
                        {
                            InfoModel.Message = "绑定成功";
                            InfoModel.ResponseCode = 0;
                        }
                        else
                        {
                            InfoModel.Message = "绑定失败";
                            InfoModel.ResponseCode = 1;
                        }
                    }
                    else
                    {
                        InfoModel.Message = "参数为空";
                        InfoModel.ResponseCode = 2;
                    }
                }
                else
                {
                    InfoModel.Message = "未分配用户名";
                    InfoModel.ResponseCode = 3;
                }
            }
            catch(Exception ex)
            {
                InfoModel.Message = "出现异常";
                InfoModel.ResponseCode = 4;
            }
            
            return InfoModel;
        }

    }
}
