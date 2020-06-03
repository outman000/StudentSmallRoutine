using Dtol;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;

namespace SmallRoutine.ConsoleSendMsg.IStudentMessageQueries
{
    public interface IMessageQueries
    {
        //7:30 提醒未进行健康信息情况填报的教职员工和学生家长 填写体温等健康信息
        List<BindMsgModel> GetListsBeforeToSchool();


        //学生 7:30 提醒未进行健康信息情况填报的 学生家长 填写体温等健康信息
        void GetListsXSBeforeToSchoolSend();


        //学生 7:30 提醒未进行健康信息情况填报的 教职工 填写体温等健康信息
        void GetListsJZGBeforeToSchoolSend();


        //教职工  9：30 提醒未进行晨检情况填报的 教职工 填写体温等健康信息
        void GetListsJZGMorningSend();


        //教职工  13：30 提醒未进行午检情况填报的 教职工 填写体温等健康信息
        void GetListsJZGNoonSend();


        string GetPage(string posturl, string postData);
    }
}
