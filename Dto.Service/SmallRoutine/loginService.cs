using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.ResponseViewModel;

namespace Dto.Service.SmallRoutine
{
  
    public class loginService: IloginService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IStudentInfoRepository _iStudentInfoRepository;
        private readonly IFacultystaffInfoRepository _facultystaffInfoRepository;
        private readonly IMapper _IMapper;

        public loginService(IUserInfoRepository userInfoRepository, IStudentInfoRepository iStudentInfoRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper)
        {
            _userInfoRepository = userInfoRepository;
            _iStudentInfoRepository = iStudentInfoRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
        }

        public ValideMiddleViewModel Login(LoginViewModel loginViewModel)
        {
            //加密信息
            var decodeloginInfp = _IMapper.Map<LoginViewModel, LoginViewModel>(loginViewModel);
            //验证是否通过
            var isSuccess=  _userInfoRepository.Login(decodeloginInfp);
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
            //加密信息
            var decodeloginInfp = _IMapper.Map<LoginViewModel, LoginViewModel>(loginViewModel);
            //验证是否通过
            var isSuccess = _userInfoRepository.Login(decodeloginInfp);
            //通过获取相关数据
            if (isSuccess)//成功则获取相关数据
            {
                var employInfo = _facultystaffInfoRepository.GetStudentInfoAndHealthInfo(decodeloginInfp.Idnumber);
                return _IMapper.Map<facultystaff_Info, ValideMiddleEmployMiddleModel>(employInfo);
            }
            else
            {
                return null;
            }
        }
    }
}
