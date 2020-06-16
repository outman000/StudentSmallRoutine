using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;

namespace Dto.Service.SmallRoutine
{
    public   class ExceptEmployService: IExceptEmployService
    {
        private readonly IExceptEmployRepository  exceptEmployRepository;
        private readonly IFacultystaffService  facultystaffService;
        private readonly IFacultystaffInfoRepository  facultystaffInfoRepository;
        private readonly IMapper _IMapper;
        private readonly ISQLRepository sQLRepository;
        public ExceptEmployService(IExceptEmployRepository exceptEmployRepository, IFacultystaffService facultystaffService,
            IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper, ISQLRepository repository)
        {
            this.exceptEmployRepository = exceptEmployRepository;
            this.facultystaffService = facultystaffService;
            this.facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
            sQLRepository = repository;
        }


        //Except_Info_Employ
        public void addExceptEmployService(ExceptEmployAddViewModel exceptEmployAddViewModel)
        {

            var insertmodel= _IMapper.Map<ExceptEmployAddViewModel, Except_Info_Employ>(exceptEmployAddViewModel);
            var employinfo = facultystaffInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(exceptEmployAddViewModel.Idnumber));
            insertmodel.facultystaff_InfoId = employinfo.id;
            exceptEmployRepository.Add(insertmodel);
            exceptEmployRepository.SaveChanges();


            //判断是否是教师  当教师发生异常，则提醒：分管领导（教务主任）、校医
            //如果是  后勤、食堂人员身体异常，则提醒：分管领导（总务主任）、校医、
 
            string StaffCode = employinfo.StaffCode;
            List<ExpectBindMsgModel> lsits = new List<ExpectBindMsgModel>();
            if (!employinfo.DepartName.Contains("餐厅") && !employinfo.StaffName.Contains("物业"))
            {
                lsits = sQLRepository.GetJZGByStaffCode(StaffCode, " DepartName like '%教务主任%' or DepartName like '%校医%' ");
            }
            if (employinfo.DepartName.Contains("餐厅") || employinfo.StaffName.Contains("物业"))
            {
                lsits = sQLRepository.GetJZGByStaffCode(StaffCode, " DepartName like '%总务主任%' or DepartName like '%校医%' ");
            }


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
                    msg.data = JsonConvert.DeserializeObject("{\"first\":{\"value\":\"" + item.name + "，你好！\",\"color\":\"#173177\"},\"keyword1\":{\"value\":\"根据本时段人员健康信息填报情况，" +
                       employinfo.StaffName + "岗位" + employinfo.Name + "出现身体异常情况，请予以重点关注。\",\"color\":\"#173177\"}," + "\"keyword2\":{\"value\":\"" + item.name + "\"," +
                       "\"color\":\"#173177\"},\"remark\":{\"value\":\"请尽快处理。\",\"color\":\"#173177\"}}");

                    string postData = JsonConvert.SerializeObject(msg);
                    string url = "https://tbl.bhteda.com/api/Message/SendMessageTest";

                    string abc = GetPage(url, postData);
                }
            }


        }

        public void deleteExceptEmployService(List<int> deleteList)
        {
            exceptEmployRepository.deleteByList(deleteList);
            exceptEmployRepository.SaveChanges();
        }

        public List<ExceptEmploySearchMiddle> searchExceptEmployService(ExceptEmploySearchViewModel exceptEmploySearchViewModel)
        {
            List<Except_Info_Employ> searchinfo= exceptEmployRepository.searchEmployinfo(exceptEmploySearchViewModel);
            var result= _IMapper.Map<List<Except_Info_Employ>,List<ExceptEmploySearchMiddle> >(searchinfo);

            return result;
        }

        public void updateExceptEmployService(ExceptEmployUpdateViewModel exceptEmployUpdateViewModel)
        {
           var updatemodel= _IMapper.Map<ExceptEmployUpdateViewModel, Except_Info_Employ>(exceptEmployUpdateViewModel);
            exceptEmployRepository.Update(updatemodel);
            exceptEmployRepository.SaveChanges();
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
