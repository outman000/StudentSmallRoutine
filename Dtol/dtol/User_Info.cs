using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Info
    {
        public int id { set; get; }
        public string Idnumber { get; set; }
        public string password { get; set ; }
        public string openid { get; set; }
        public string unionid { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public virtual ICollection<User_Relate_Info_Role> User_Relate_Info_Role { get; set; }

    }
}
