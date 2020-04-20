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

    }
}
