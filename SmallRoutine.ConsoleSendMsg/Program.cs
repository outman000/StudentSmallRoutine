using Microsoft.Extensions.DependencyInjection;
using SmallRoutine.ConsoleSendMsg.StudentMessageQueries;
using System;
using System.Collections.Generic;

namespace SmallRoutine.ConsoleSendMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            //测试 7:30 提醒未进行健康信息情况填报的教职员工和学生家长 填写体温等健康信息
            var aa = new MessageQueries();
            List<string> list1 = aa.GetListsBeforeToSchool();
            foreach (var item in list1)
            {
                Console.WriteLine("当天7:30计算成功" + item.ToString());
            }
 
            Console.WriteLine("输入任意键停止");
            Console.ReadLine();
  
        }
    }
}
