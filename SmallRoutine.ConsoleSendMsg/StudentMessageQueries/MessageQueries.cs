using Dtol;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using SmallRoutine.ConsoleSendMsg.IStudentMessageQueries;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ViewModel.SmallRoutine.RequestViewModel;
using System.Net;
using ViewModel.SmallRoutine.MiddelViewModel;
using Newtonsoft.Json;

namespace SmallRoutine.ConsoleSendMsg.StudentMessageQueries
{
    public class MessageQueries: IMessageQueries
    {
        private string _connectionString = string.Empty;

        public MessageQueries()
        {
            _connectionString = "Server=192.168.25.128;Database=StudentSmallRoutine;uid=sa;pwd=Admin@123.0;Max Pool Size=1500;";
            //var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            //_connectionString = configuration.GetConnectionString("SqlServerConnection");
        }

        //7:30 提醒未进行健康信息情况填报的教职员工和学生家长 填写体温等健康信息
        public List<BindMsgModel> GetListsBeforeToSchool()
        {
 
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber,a.openid,a.unionid from User_Info a  where IdNumber not in ( select  b.IdNumber from  Health_Info b  where CONVERT(VARCHAR(50),b.Createdate,23)='" + DateTime.Now + "' and  checktype='到校前' ) ";
                var result = connection.Query<BindMsgModel>(sql).AsList();
                connection.Close();
                return result;
            }

        }

        //学生 7:30 提醒未进行健康信息情况填报的 学生家长 填写体温等健康信息
        public void GetListsXSBeforeToSchoolSend()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber,CASE WHEN d.Name is null THEN '' ELSE d.Name END as openid,a.unionid " +
                     " from Student_Info d left join User_Info a  on a.Idnumber = d.IdNumber " +
                     " where d.IdNumber not in (select  b.IdNumber from  Health_Info b " +
                     " where CONVERT(VARCHAR(50),b.Createdate,23)= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and checktype = '到校前' )  and unionid is not null ";
                var result = connection.Query<BindMsgModel>(sql).AsList();
                connection.Close();

                foreach (var item in result)
                {
                    string openid = item.openid;
                    string unionid = item.unionid;
                    string serviceOpenid = "";
                    string connectionnew = "Server=10.128.20.60;Database=TedaEasyDB;uid=sa;pwd=P@ssw0rd#2020;";
                    //string connectionnew = "Server=D41ICKRFDL1HRNM;Database=TedaEasyDB;Trusted_Connection=True;";
                    using (var connection2= new SqlConnection(connectionnew))
                    {
                        connection2.Open();
                        string str = "  select  a.openid  from UserOpenidForWeChat a where a.unionid='" + unionid + "' and  appid='wx89c4cffa70434fe4'  ";
                        var res = connection2.Query<string>(str);
                        connection2.Close();
                        if (res.AsList().Count != 0)
                        {
                            foreach (string item1 in res)
                            {
                                serviceOpenid = item1.ToString();
                                //判断 接收者openid 不为空
                                if (!string.IsNullOrEmpty(serviceOpenid))
                                {
                                    SendMessageModel msg = new SendMessageModel();
                                    msg.touser = serviceOpenid;
                                    msg.miniprogram = JsonConvert.DeserializeObject("{\"appid\":\"wx1b4d3e31ba3454d6\",\"pagepath\":\"pages/home/home\"}");
                                    msg.template_id = "PLcY90Q4RtD8fDplfP-Vfh_8oVy7l4ABUtFmX_Tm9Jw";
                                    msg.url = "";
                                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + openid + "家长，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"距离本时段健康信息填报还有30分钟，请您尽快完成学生离家前健康信息填报，谢谢您的配合。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + openid + "\"," +
                                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                                    string postData = JsonConvert.SerializeObject(msg);
                                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                                    string abc = GetPage(url, postData);

                                    Console.WriteLine("教职工信息当天7:30计算成功:" + item.ToString() + ";获取openid=" + serviceOpenid + "推送结果：" + abc);
                                }
                               
                            }
                        }

                      
                    }
                }
            }
        }



        //教职工 7:30 提醒未进行健康信息情况填报的 教职工 填写体温等健康信息
        public void GetListsJZGBeforeToSchoolSend()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber,CASE WHEN d.Name is null THEN '' ELSE d.Name END as openid,a.unionid " +
                     " from facultystaff_Info d left join User_Info a  on a.Idnumber = d.IdNumber " +
                     " where d.IdNumber not in (select  b.IdNumber from  Health_Info b " +
                     " where CONVERT(VARCHAR(50),b.Createdate,23)= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and checktype = '到校前' )  and unionid is not null ";
                var result = connection.Query<BindMsgModel>(sql).AsList();
                connection.Close();

                foreach (var item in result)
                {
                    string openid = item.openid;
                    string unionid = item.unionid;
                    string serviceOpenid = "";
                    string connectionnew = "Server=10.128.20.60;Database=TedaEasyDB;uid=sa;pwd=P@ssw0rd#2020;";
 
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
                                if (!string.IsNullOrEmpty(serviceOpenid))
                                {
                                    SendMessageModel msg = new SendMessageModel();
                                    msg.touser = serviceOpenid;
                                    msg.miniprogram = JsonConvert.DeserializeObject("{\"appid\":\"wx1b4d3e31ba3454d6\",\"pagepath\":\"pages/home/home\"}");
                                    msg.template_id = "PLcY90Q4RtD8fDplfP-Vfh_8oVy7l4ABUtFmX_Tm9Jw";
                                    msg.url = "";
                                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + openid + "，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"距离本时段健康信息填报还有30分钟，请您尽快完成离家前健康信息填报，谢谢您的配合。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + openid + "\"," +
                                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                                    string postData = JsonConvert.SerializeObject(msg);
                                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                                    string abc = GetPage(url, postData);

                                    Console.WriteLine("学生信息当天7:30计算成功:" + item.Idnumber + ";获取openid=" + serviceOpenid + "推送结果：" + abc);
                                }
                               
                            }
                        }

                    
                 
                    }
                }
            }
        }



        //教职工  10：00 提醒未进行晨检情况填报的 教职工 填写体温等健康信息
        public void GetListsJZGMorningSend()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber,CASE WHEN d.Name is null THEN '' ELSE d.Name END as openid,a.unionid " +
                     " from facultystaff_Info d left join User_Info a  on a.Idnumber = d.IdNumber " +
                     " where d.IdNumber not in (select  b.IdNumber from  Health_Info b " +
                     " where CONVERT(VARCHAR(50),b.Createdate,23)= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and checktype = '晨' )  and unionid is not null ";
                var result = connection.Query<BindMsgModel>(sql).AsList();
                connection.Close();

                foreach (var item in result)
                {
                    string openid = item.openid;
                    string unionid = item.unionid;
                    string serviceOpenid = "";
                    string connectionnew = "Server=10.128.20.60;Database=TedaEasyDB;uid=sa;pwd=P@ssw0rd#2020;";

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
                                serviceOpenid = item1.ToString();
                                if (!string.IsNullOrEmpty(serviceOpenid))
                                {
                                    SendMessageModel msg = new SendMessageModel();
                                    msg.touser = serviceOpenid;
                                    msg.miniprogram = JsonConvert.DeserializeObject("{\"appid\":\"wx1b4d3e31ba3454d6\",\"pagepath\":\"pages/home/home\"}");
                                    msg.template_id = "PLcY90Q4RtD8fDplfP-Vfh_8oVy7l4ABUtFmX_Tm9Jw";
                                    msg.url = "";
                                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + openid + "，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"距离本时段健康信息填报还有30分钟，请您尽快完成填报，谢谢您的配合。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + openid + "\"," +
                                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                                    string postData = JsonConvert.SerializeObject(msg);
                                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                                    string abc = GetPage(url, postData);

                                    Console.WriteLine("教职工信息当天10：00计算成功:" + item.Idnumber + ";获取openid=" + serviceOpenid + "推送结果：" + abc);
                                }
                              
                            }
                        }
                    }
                }
            }
        }


        //教职工  13：30 提醒未进行午检情况填报的 教职工 填写体温等健康信息
        public void GetListsJZGNoonSend()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "  select a.IdNumber,CASE WHEN d.Name is null THEN '' ELSE d.Name END as openid,a.unionid " +
                     " from facultystaff_Info d left join User_Info a  on a.Idnumber = d.IdNumber " +
                     " where d.IdNumber not in (select  b.IdNumber from  Health_Info b " +
                     " where CONVERT(VARCHAR(50),b.Createdate,23)= '" + DateTime.Now.ToString("yyyy-MM-dd") + "' and checktype = '午' )  and unionid is not null ";
                var result = connection.Query<BindMsgModel>(sql).AsList();
                connection.Close();

                foreach (var item in result)
                {
                    string openid = item.openid;
                    string unionid = item.unionid;
                    string serviceOpenid = "";
                    string connectionnew = "Server=10.128.20.60;Database=TedaEasyDB;uid=sa;pwd=P@ssw0rd#2020;";

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
                                serviceOpenid = item1.ToString();
                                if (!string.IsNullOrEmpty(serviceOpenid))
                                {
                                    SendMessageModel msg = new SendMessageModel();
                                    msg.touser = serviceOpenid;
                                    msg.miniprogram = JsonConvert.DeserializeObject("{\"appid\":\"wx1b4d3e31ba3454d6\",\"pagepath\":\"pages/home/home\"}");
                                    msg.template_id = "PLcY90Q4RtD8fDplfP-Vfh_8oVy7l4ABUtFmX_Tm9Jw";
                                    msg.url = "";
                                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + openid + "，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"距离本时段健康信息填报还有30分钟，请您尽快完成填报，谢谢您的配合。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + openid + "\"," +
                                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                                    string postData = JsonConvert.SerializeObject(msg);
                                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                                    string abc = GetPage(url, postData);

                                    Console.WriteLine("教职工信息当天13:30计算成功:" + item.Idnumber + ";获取openid=" + serviceOpenid + "推送结果：" + abc);

                                }
                            }
                        }


                    
                    }
                }
            }
        }


        public string GetPage(string posturl, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...
            try
            {
                // 设置参数
                request = WebRequest.Create(posturl) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    response = (HttpWebResponse)ex.Response;
                }
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

    }
}
