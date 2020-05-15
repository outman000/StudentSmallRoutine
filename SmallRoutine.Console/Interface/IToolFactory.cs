using Dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmallRoutineTiming.Interface
{
     public  interface IToolFactory 
    {
        DtolContext getDbContext();
        // MysqlContext getMysqlDbContext();
    }
}
