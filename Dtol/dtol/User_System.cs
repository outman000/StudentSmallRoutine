using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_System
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
 
        public DateTime? AddDate { get; set; }
        public DateTime? updateDate { get; set; }

        //public virtual ICollection<User_Relate_Info_Role> User_Relate_Info_Role { get; set; }
    }
}
