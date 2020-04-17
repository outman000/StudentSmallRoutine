using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthViewModel;

namespace Dto.Service.SmallRoutine
{
    public class HealthRegisterService : IHealthRegisterService
    {
        private readonly IMapper _IMapper;
        private readonly IHealthRegisterRepository healthRegisterRepository;
        private readonly IFacultystaffInfoRepository  facultystaffInfoRepository;
        private readonly IStudentInfoRepository  studentInfoRepository;

        public HealthRegisterService(IMapper iMapper, IHealthRegisterRepository healthRegisterRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IStudentInfoRepository studentInfoRepository)
        {
            _IMapper = iMapper;
            this.healthRegisterRepository = healthRegisterRepository;
            this.facultystaffInfoRepository = facultystaffInfoRepository;
            this.studentInfoRepository = studentInfoRepository;
        }


        /// <summary>
        /// 添加登记健康信息
        /// </summary>
        /// <param name="healthViewModel"></param>

        public void addHealthRegisterInfo(HealthInfoAddViewModel healthViewModel)
        {
            var insertInfo= _IMapper.Map<HealthInfoAddViewModel, StudentRegisterHeath_Info>(healthViewModel);
            healthRegisterRepository.Add(insertInfo);
            healthRegisterRepository.SaveChanges();//保存数据


            var insertHealth = healthRegisterRepository.getByidNumber(insertInfo.Idnumber);//查询插入的 mapper中加密
            var facultystaff = facultystaffInfoRepository.getByidNumber(insertInfo.Idnumber);//查询白绑定的基础信息
            var studentInfo = studentInfoRepository.getByidNumber(insertInfo.Idnumber);
            if (facultystaff != null)//不为空复制键值
            {
                facultystaff.StudentRegisterHeath_InfoId = insertHealth.id;
                facultystaffInfoRepository.Update(facultystaff);
            }
            if (studentInfo != null)
            {
                studentInfo.StudentRegisterHeath_InfoId = insertHealth.id;
                studentInfoRepository.Update(studentInfo);
            }
            healthRegisterRepository.SaveChanges();
        }
        /// <summary>
        /// 删除登记健康信息
        /// </summary>
        /// <param name="healthInfoDeleteViewModel"></param>
        public void DeleteHealthRegisterInfo(HealthInfoDeleteViewModel healthInfoDeleteViewModel)
        {
          
            healthRegisterRepository.DelByList(healthInfoDeleteViewModel.DeleteList);
            healthRegisterRepository.SaveChanges();
        }
        /// <summary>
        /// 查询登记健康信息
        /// </summary>
        /// <param name="healthInfoSearchViewModel"></param>
        /// <returns></returns>

        public List<HealthInfoSearchMiddle> SearchHealthRegisterInfo(HealthInfoSearchViewModel healthInfoSearchViewModel)
        {
            var searchResult= healthRegisterRepository.searchHealthInfo(healthInfoSearchViewModel);
            var searchresult = _IMapper.Map<List<StudentRegisterHeath_Info>, List<HealthInfoSearchMiddle>>(searchResult);
            return searchresult;
        }
        /// <summary>
        /// 更新登记健康信息
        /// </summary>
        /// <param name="healthInfoUpdateViewModel"></param>
        public void UpdateHealthRegisterInfo(HealthInfoUpdateViewModel healthInfoUpdateViewModel)
        {
            var insertInfo = _IMapper.Map<HealthInfoUpdateViewModel, StudentRegisterHeath_Info>(healthInfoUpdateViewModel);
            healthRegisterRepository.Update(insertInfo);
            healthRegisterRepository.SaveChanges();
        }



    }
}
