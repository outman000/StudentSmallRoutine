using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace SmallRoutine.ConsoleSendMsg.IStudentMessageQueries
{
    public interface IMessageQueries
    {
        //7:30 提醒未进行健康信息情况填报的教职员工和学生家长 填写体温等健康信息
        List<string> GetListsBeforeToSchool();
    }
}
