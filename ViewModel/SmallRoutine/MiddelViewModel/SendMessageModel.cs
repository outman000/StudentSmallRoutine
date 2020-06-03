using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public  class SendMessageModel
    { //接收者（用户）的 openid
        public string touser { get; set; }
        //所需下发的订阅模板id
        public string template_id { get; set; }
        //模板跳转链接（海外帐号没有跳转能力）非必填
        public string url { get; set; }
        //跳小程序所需数据，不需跳小程序可不用传该数据，格式形如 { "appid": "", "pagepath": "" }
        public object miniprogram { get; set; }
        //模板内容，格式形如 { "key1": { "value": any,"color":"#173177" }, "key2": { "value": any,"color":"#173177"  } }
        public object data { get; set; }
    }
}
