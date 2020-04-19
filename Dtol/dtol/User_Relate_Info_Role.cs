using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class User_Relate_Info_Role
    {
      
        public int Id { get; set; }

        public int User_SystemId { get; set; }

        public User_System User_System { get; set; }

        public int Station_InfoId { get; set; }

        public Station_Info Station_Info { get; set; }

    }
}
