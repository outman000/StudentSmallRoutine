
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace Dto.IRepository.SmallRoutine
{
    public interface IWeChatClientRepository
    {
        string GetOpenIdAndSessionKeyString(string code, string appId, string appSecret);

 
        WeChatInfoModel Decrypt(string code, string appId, string appSecret);
    }
}
