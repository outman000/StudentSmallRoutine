using Microsoft.Extensions.DependencyInjection;
using SmallRoutine.ConsoleSendMsg.StudentMessageQueries;
using System;
using System.Collections.Generic;
using ViewModel.SmallRoutine.RequestViewModel;

namespace SmallRoutine.ConsoleSendMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var service = new MessageQueries();

            int hour = DateTime.Now.Hour;
            int Minute = DateTime.Now.Minute;

            if (hour == 7 && Minute == 30)
            {
                // 7:30 提醒未进行健康信息情况填报的学生家长 填写体温等健康信息
                service.GetListsXSBeforeToSchoolSend();
                // 7:30 提醒未进行健康信息情况填报的教职员工填写体温等健康信息
                service.GetListsJZGBeforeToSchoolSend();
            }
            else if (hour == 10 && Minute == 0)
            {
                //教职工  10：00 提醒未进行晨检情况填报的 教职工 填写体温等健康信息
                service.GetListsJZGMorningSend();
            }
            else if (hour == 13 && Minute == 30)
            {
                //教职工  13：30 提醒未进行午检情况填报的 教职工 填写体温等健康信息
                service.GetListsJZGNoonSend();
            }
          
 
  
        }
    }
}
