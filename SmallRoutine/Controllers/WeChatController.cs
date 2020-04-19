using Dto.IService.SmallRoutine;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
