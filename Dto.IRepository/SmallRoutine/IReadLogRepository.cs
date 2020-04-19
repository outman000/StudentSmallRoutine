using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.IRepository.SmallRoutine
{
    public interface IReadLogRepository : IRepository<ReadLog>
    {
        //获取用户阅读政策记录
        ReadLog GetReadLog(string opendi);
    }
}
