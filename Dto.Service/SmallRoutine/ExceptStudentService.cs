using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;
using Newtonsoft.Json;

namespace Dto.Service.SmallRoutine
{
    public class ExceptStudentService: IExceptStudentService
    {
        private readonly IExceptStudentRepository  exceptStudentRepository;
        private readonly IStudentInfoRepository studentInfoRepository;
        private readonly ISQLRepository sQLRepository;
        private readonly IMapper _IMapper;

        public ExceptStudentService(IExceptStudentRepository exceptStudentRepository, IStudentInfoRepository studentInfoRepository, IMapper iMapper, ISQLRepository repository)
        {
            this.exceptStudentRepository = exceptStudentRepository;
            this.studentInfoRepository = studentInfoRepository;
            _IMapper = iMapper;
            sQLRepository = repository;
        }

        public void addExceptStudentAddService(ExceptStudentAddViewModel exceptStudentAddViewModel)
        {
            var  insertmodel= _IMapper.Map<ExceptStudentAddViewModel, Except_Info_Student>(exceptStudentAddViewModel);
            //学生信息
            var studentInfo = studentInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(exceptStudentAddViewModel.Idnumber));
        
                insertmodel.student_InfoId = studentInfo.id;
                exceptStudentRepository.Add(insertmodel);
                exceptStudentRepository.SaveChanges();

            ///学生异常信息上报，上报完成 推送模板消息 通知所属的班主任、教务主任、校医。  20200609
            //查找所属班主任、教务主任、校医
            string classCode = studentInfo.ClassCode;

            var lsits = sQLRepository.GetJZGByClassCode(classCode, " DepartName like '%教务主任%' or DepartName like '%班主任%' or DepartName like '%校医%' ");
            foreach (var item in lsits)
            {
 
                string unionid = item.unionid;
                string serviceOpenid = "";
                serviceOpenid = sQLRepository.GetOpenidByUnionid(unionid);
                if (!string.IsNullOrEmpty(serviceOpenid))
                {
                    SendMessageModel msg = new SendMessageModel();
                    msg.touser = serviceOpenid;
                    msg.miniprogram = JsonConvert.DeserializeObject("{\"appid\":\"wx1b4d3e31ba3454d6\",\"pagepath\":\"pages/home/home\"}");
                    msg.template_id = "PLcY90Q4RtD8fDplfP-Vfh_8oVy7l4ABUtFmX_Tm9Jw";
                    msg.url = "";
                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + item.name + "，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"根据本时段人员健康信息填报情况，"+
                       studentInfo.GradeName + "年级"+ studentInfo.ClassName + "班"+ studentInfo.Name + "出现身体异常情况，请予以重点关注。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + item.name + "\"," +
                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                    string postData = JsonConvert.SerializeObject(msg);
                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                    string abc = GetPage(url, postData);
                }
            }
 

        }

        public void SearchExceptStudengDeleteService(List<int> deleteList)
        {
            exceptStudentRepository.deletebyList(deleteList);
            exceptStudentRepository.SaveChanges();
        }

        public List<ExceptStudentSearchMiddle> SearchExceptStudengSearchService(ExceptStudengSearchInfoVIewModel exceptStudentSearchInfoVIewModel)
        {
         var resultsearch=  exceptStudentRepository.searchByemploytoclass(exceptStudentSearchInfoVIewModel);
          var result= _IMapper.Map<List<Except_Info_Student>,List<ExceptStudentSearchMiddle> >(resultsearch); 

            return result; 
        }

        public void updateExceptStudentUpdateServide(ExceptStudentUpdateViewModel exceptStudentUpdateViewModel)
        {
            var updatemodel = _IMapper.Map<ExceptStudentUpdateViewModel, Except_Info_Student>(exceptStudentUpdateViewModel);
            exceptStudentRepository.Update(updatemodel);
            exceptStudentRepository.SaveChanges();
        }


        public virtual string GetPage(string posturl, string postData)
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
