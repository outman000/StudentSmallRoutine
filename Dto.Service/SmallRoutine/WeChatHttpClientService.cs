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

namespace Dto.Service.SmallRoutine
{
    class WeChatHttpClientService: IWeChatHttpClientService
    {
 
        private readonly IWeChatClientRepository _IWeChatClientRepository;
        private readonly IMapper _IMapper;
        private IOptions<WeChartTokenMiddles> _IOptions;

        public WeChatHttpClientService(IWeChatClientRepository repository, IMapper mapper,IOptions<WeChartTokenMiddles> iOptions)
        {
            _IWeChatClientRepository = repository;
            _IOptions = iOptions;
            _IMapper = mapper;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        public WeChatInfoModel GetWeChartUserInfo(WeChatCodeModel codeModel)
        {
            WeChatInfoModel InfoModel = _IWeChatClientRepository.Decrypt(codeModel.code, _IOptions.Value.appid, _IOptions.Value.secret);
            return InfoModel;
        }
    }
}
