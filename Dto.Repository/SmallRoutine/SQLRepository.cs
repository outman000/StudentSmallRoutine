using Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ViewModel.SmallRoutine.RequestViewModel;
using System.Net;
using ViewModel.SmallRoutine.MiddelViewModel;
using Newtonsoft.Json;
using Dto.IRepository.SmallRoutine;

namespace Dto.Repository.SmallRoutine
{
    public class SQLRepository: ISQLRepository
    {
        protected string _connectionString = string.Empty;

        public SQLRepository(string con)
        {
            _connectionString = con;
        }


        //根据 学生 班级信息 查询对应的 班主任、教务主任、校医等 信息（unionid,openid等）
        public List<ExpectBindMsgModel> GetJZGByClassCode(string ClassCode,string dept)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select  a.IdNumber, f.Name,f.DepartName,f.StaffName,a.unionid   " +
                     " from  facultystaff_Info f  left join User_Info a  on a.Idnumber = f.IdNumber  " +
                     " where  f.id  in (select facultystaff_InfoId   FROM ClassManager_Relate  " +
                     " where ClassCode='" + ClassCode + "'  and  facultystaff_InfoId in   " +
                     " (select id FROM facultystaff_Info where   " + dept + "  ))   " +
                     " and a.unionid is not null ";
                var result = connection.Query<ExpectBindMsgModel>(sql).AsList();
                connection.Close();

                return result;

            }
        }


        //根据 教职工 岗位信息 查询对应的 教务主任或总务主任、校医等 信息（unionid,openid等）
        public List<ExpectBindMsgModel> GetJZGByStaffCode(string StaffCode, string dept)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select  a.IdNumber, f.Name,f.DepartName,f.StaffName,a.unionid   " +
                     " from  facultystaff_Info f  left join User_Info a  on a.Idnumber = f.IdNumber  " +
                     " where  f.id  in (select facultystaff_InfoId   FROM StaffStation_Relate  " +
                     " where StaffCode='" + StaffCode + "'  and  facultystaff_InfoId in   " +
                     " (select id FROM facultystaff_Info where   " + dept + "  ))   " +
                     " and a.unionid is not null ";
                var result = connection.Query<ExpectBindMsgModel>(sql).AsList();
                connection.Close();

                return result;

            }
        }


        //根据unionid 获取 关注服务号对应的 openid
        public string GetOpenidByUnionid(string unionid)
        {
            string serviceOpenid = "";
            string connectionnew = "Server=D41ICKRFDL1HRNM;Database=TedaEasyDB;uid=sa;pwd=App1234;";

            using (var connection2 = new SqlConnection(connectionnew))
            {
                connection2.Open();
                string str = "  select  a.openid  from UserOpenidForWeChat a where a.unionid='" + unionid + "' and  appid='wx89c4cffa70434fe4'  ";
                var res = connection2.Query<string>(str);
                connection2.Close();
                if (res.AsList().Count != 0)
                {
                    foreach (string item1 in res)
                    {
                        //接收者 openid 不为空
                        serviceOpenid = item1.ToString();
                    }
                }
            }

            return serviceOpenid;
        }

    }
}
