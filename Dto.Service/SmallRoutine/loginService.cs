﻿using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace Dto.Service.SmallRoutine
{

    public class loginService : IloginService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IStudentInfoRepository _iStudentInfoRepository;
        private readonly IFacultystaffInfoRepository _facultystaffInfoRepository;
        private readonly IMapper _IMapper;
        private readonly IUser_GroupRepository _GroupRepository;

        public loginService(IUserInfoRepository userInfoRepository, IStudentInfoRepository iStudentInfoRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper, IUser_GroupRepository groupRepository)
        {
            _userInfoRepository = userInfoRepository;
            _iStudentInfoRepository = iStudentInfoRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
            _GroupRepository = groupRepository;
        }

        public ValideMiddleViewModel Login(LoginViewModel loginViewModel)
        {
            //加密信息
            var decodeloginInfp = _IMapper.Map<LoginViewModel, LoginViewModel>(loginViewModel);
            if (decodeloginInfp == null)
            {
                return null;
            }
            //验证是否通过
            var isSuccess = _userInfoRepository.Login(decodeloginInfp);
            //通过获取相关数据
            if (isSuccess)//成功泽获取相关数据
            {
                var userInfo = _iStudentInfoRepository.GetStudentInfoAndHealthInfo(decodeloginInfp.Idnumber);
                return _IMapper.Map<Student_Info, ValideMiddleViewModel>(userInfo);
            }
            else
            {
                return null;
            }
        }

        public ValideMiddleEmployMiddleModel LoginEmploy(LoginViewModel loginViewModel)
        {
            ValideMiddleEmployMiddleModel result = new ValideMiddleEmployMiddleModel();
            //加密信息
            var decodeloginInfp = _IMapper.Map<LoginViewModel, LoginViewModel>(loginViewModel);
            //验证是否通过
            var isSuccess = _userInfoRepository.Login(decodeloginInfp);
            //通过获取相关数据
            if (isSuccess)//成功则获取相关数据
            {
                var employInfo = _facultystaffInfoRepository.GetStudentInfoAndHealthInfo(decodeloginInfp.Idnumber);
                result = _IMapper.Map<facultystaff_Info, ValideMiddleEmployMiddleModel>(employInfo);
                result.RoleID = GetRoleID(result.DepartName);
                return result;
            }
            else
            {
                return null;
            }
        }
        private string GetRoleID(string stationName)
        {
            string result = string.Empty;
            var list = _GroupRepository.GetUser_GroupsByStationName(stationName);
            if (list.Count > 0)
            {
                result = list[0].Code;
            }
            return result;
        }
        //修改密码
        public BaseViewModel EditPwdView(EditPwdViewModel editPwdView)
        {
            BaseViewModel baseView = new BaseViewModel();

            //加密信息
            LoginViewModel decodeloginInfp = new LoginViewModel();
            decodeloginInfp.Idnumber = Dtol.Helper.MD5.Md5Hash(editPwdView.Idnumber);
            decodeloginInfp.Password = Dtol.Helper.MD5.Md5Hash(editPwdView.OldPassword);
            //验证是否通过
            var isSuccess = _userInfoRepository.Login(decodeloginInfp);
            //通过获取相关数据
            if (isSuccess)//成功则获取相关数据
            {
                User_Info Info = new User_Info();
                Info = _userInfoRepository.GetByIdnumber(editPwdView.Idnumber);
                Info.Idnumber = Dtol.Helper.MD5.Md5Hash(editPwdView.Idnumber);
                Info.password = Dtol.Helper.MD5.Md5Hash(editPwdView.NewPassword);
                _userInfoRepository.Update(Info);
                int i = _userInfoRepository.SaveChanges();
                if (i > 0)
                {
                    baseView.Message = "修改成功";
                    baseView.ResponseCode = 0;
                }
                else
                {
                    baseView.Message = "修改失败";
                    baseView.ResponseCode = 1;
                }
            }
            else
            {
                baseView.Message = "原密码不对";
                baseView.ResponseCode = 2;

            }
            return baseView;
        }

        public bool LoginAdmin(LoginViewModel loginViewModel)
        {
            var decodeloginInfp = _IMapper.Map<LoginViewModel, LoginViewModel>(loginViewModel);
            //验证是否通过
            return _userInfoRepository.Login(decodeloginInfp);
        }

        public void ResetPwd(string idnumber)
        {
            var result = _userInfoRepository.GetByIdnumber(idnumber);
            result.password = Dtol.Helper.MD5.Md5Hash("ET2020666");
            _userInfoRepository.Update(result);
            _userInfoRepository.SaveChanges();
        }
    }
}
