using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class EmployHealthInfoSearchMiddle
    {
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
        /// <summary>
        /// 暂住在津地址
        /// </summary>
        public string Residencetemporary { get; set; }//在津暂住地址
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 监护人
        /// </summary>
        public string Guardian { get; set; }
        /// <summary>
        /// 是否离开天津
        /// </summary>
        public string IsleaveJin { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// 返金日期
        /// </summary>
        public DateTime? BackJinDate { get; set; }
        /// <summary>
        /// 是否经过湖北
        /// </summary>
        public string IsPassHubei { get; set; }
        /// <summary>
        /// 湖北集体抵制
        /// </summary>
        public string PassHubeiDetail { get; set; }//经过湖北具体地址
        /// <summary>
        /// 交通方式
        /// </summary>
        public string Traffic { get; set; }
        /// <summary>
        /// 同行人
        /// </summary>
        public string Peers { get; set; }//同行人
        /// <summary>
        /// 同行人联系方式
        /// </summary>
        public string PeersTelephone { get; set; }//同行人联系方式
        /// <summary>
        /// 十四天内异常情况
        /// </summary>
        public string ForteenDaysExcepting { get; set; }//14填异常
        /// <summary>
        /// 本人抵达天津14天前
        /// </summary>
        public string BeforeTianjin { get; set; }//本人抵达天津前14天
        /// <summary>
        /// 体温计
        /// </summary>
        public string Temperature { get; set; }//体温
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }
    }
}
