using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel;

namespace Dto.Service.SmallRoutine
{
    public class HealthService: IHealthService
    {
        private readonly IMapper _IMapper;
        private readonly IHealthRepository  healthRepository;
        private readonly IFacultystaffInfoRepository facultystaffInfoRepository;
        private readonly IStudentInfoRepository studentInfoRepository;

        public HealthService(IMapper iMapper, IHealthRepository healthRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IStudentInfoRepository studentInfoRepository)
        {
            _IMapper = iMapper;
            this.healthRepository = healthRepository;
            this.facultystaffInfoRepository = facultystaffInfoRepository;
            this.studentInfoRepository = studentInfoRepository;
        }

        //Health_Info
        public void addHealthEveryRegisterInfo(HealthEveryAddViewModel healthEveryAddViewModel)
        {

            var insertInfo = _IMapper.Map<HealthEveryAddViewModel, Health_Info>(healthEveryAddViewModel);
            var isexist= healthRepository.existhealthInfo(healthEveryAddViewModel);

            if (!isexist)
            {
                healthRepository.Add(insertInfo);
                healthRepository.SaveChanges();//添加每日健康信息

                //hc注释
                //var insertHealth = healthRepository.getByidNumber(insertInfo.IdNumber);//查询插入的 mapper中加密
                //var facultystaff = facultystaffInfoRepository.getByidNumber(insertInfo.IdNumber);//查询白绑定的基础信息
                //var studentInfo = studentInfoRepository.getByidNumber(insertInfo.IdNumber);

                //if (facultystaff != null)//不复制键值
                //{
                //    insertInfo.facultystaff_InfoId = facultystaff.id;
                //    healthRepository.Update(insertInfo);
                //}
                //if (studentInfo != null)
                //{
                //    insertInfo.Student_InfoId = studentInfo.id;
                //    healthRepository.Update(insertInfo);
                //}
                //healthRepository.SaveChanges();
            }
        }
        //补录
        public void collectionHealthEveryRegisterInfo(HealthEveryCollectionViewModel healthEveryAddViewModel)
        {

            var insertInfo = _IMapper.Map<HealthEveryCollectionViewModel, Health_Info>(healthEveryAddViewModel);
            var isexist = healthRepository.collectionexisthealthInfo(healthEveryAddViewModel);

            if (!isexist)
            {
                healthRepository.Add(insertInfo);
                healthRepository.SaveChanges();//添加每日健康信息


                //var insertHealth = healthRepository.getByidNumber(insertInfo.IdNumber);//查询插入的 mapper中加密
                //var facultystaff = facultystaffInfoRepository.getByidNumber(insertInfo.IdNumber);//查询白绑定的基础信息
                //var studentInfo = studentInfoRepository.getByidNumber(insertInfo.IdNumber);

                //if (facultystaff != null)//不复制键值
                //{
                //    insertInfo.facultystaff_InfoId = facultystaff.id;
                //    healthRepository.Update(insertInfo);
                //}
                //if (studentInfo != null)
                //{
                //    insertInfo.Student_InfoId = studentInfo.id;
                //    healthRepository.Update(insertInfo);
                //}
                //healthRepository.SaveChanges();
            }
        }



        public void DeleteHealthEveryRegisterInfo(HealthEveryDeleteViewModel healthEveryDeleteViewModel)
        {
            healthRepository.DelByList(healthEveryDeleteViewModel.DeleteList);
            healthRepository.SaveChanges();
        }

        public List<HealthEverySearchMiddleModel> SearchHealthEveryRegisterInfo(HealthEverySearchViewModel healthEverySearchViewModel)
        {
            var result = healthRepository.SearchHealthEveryRegisterInfo(healthEverySearchViewModel);
            var searchresult = _IMapper.Map<List<Health_Info>, List<HealthEverySearchMiddleModel>>(result);
            return searchresult;
        }

        public void UpdateHealthEveryRegisterInfo(HealthEveryUpdateViewModel healthEveryUpdateViewModel)
        {
            var updateInfo = _IMapper.Map<HealthEveryUpdateViewModel, Health_Info>(healthEveryUpdateViewModel);
            healthRepository.Update(updateInfo);
            healthRepository.SaveChanges();
        }
    }
}
