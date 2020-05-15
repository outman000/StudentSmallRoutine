using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public  class StudentRegisterHeath_Info
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Idnumber { get; set; }
        public string Residencetemporary { get; set; }//在津暂住地址
        public string Telephone { get; set; }
        public string Guardian { get; set; }
        public string IsleaveJin { get; set; }
        public string Destination { get; set; }
        public DateTime? BackJinDate { get; set; }
        public string IsPassHubei { get; set; }
        public string PassHubeiDetail { get; set; }//经过湖北具体地址
        public string Traffic { get; set; }
        public string Peers { get; set; }//同行人
        public string PeersTelephone { get; set; }//同行人联系方式
        public string ForteenDaysExcepting { get; set; }//14填异常
        public string BeforeTianjin { get; set; }//本人抵达天津前14天
        public string Temperature { get; set; }//体温

        public DateTime? CreateDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }

    }
}
