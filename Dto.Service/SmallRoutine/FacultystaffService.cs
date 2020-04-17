using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using Dtol.Extension;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;
using ViewModel.SmallRoutine.RequestViewModel;
using ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel;
using ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel;

namespace Dto.Service.SmallRoutine
{
    public class FacultystaffService: IFacultystaffService
    {
        private readonly IStaffClassRelateRepository staffClassRelateRepository;
        private readonly IFacultystaffInfoRepository  _facultystaffInfoRepository;
        private readonly IMapper _IMapper;
        private readonly ISchoolInfoRepository _schoolInfoRepository;

        public FacultystaffService(IStaffClassRelateRepository staffClassRelateRepository, IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper, ISchoolInfoRepository schoolInfoRepository)
        {
            this.staffClassRelateRepository = staffClassRelateRepository;
            _facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
            _schoolInfoRepository = schoolInfoRepository;
        }




        //添加教职工信息 
        public BaseViewModel addFacultystaffInfo(FacultystaffBaseModel  model)
        {
            BaseViewModel viewModel = new BaseViewModel();

            try
            {
                //验证 学校 是否存在
                if (_schoolInfoRepository.CheckInfo(model.SchoolCode, model.SchoolName))
                {

                    facultystaff_Info info = new facultystaff_Info();
                    info = _IMapper.Map<FacultystaffBaseModel, facultystaff_Info>(model);
                    info.CreateDate = DateTime.Now;
                    _facultystaffInfoRepository.Add(info);
                    int i = _facultystaffInfoRepository.SaveChanges();
                    if (i > 0)
                    {
                        viewModel.ResponseCode = 0;
                        viewModel.Message = "信息添加成功";
                    }
                    else
                    {
                        viewModel.ResponseCode = 1;
                        viewModel.Message = "信息添加失败";
                    }
                }
                else
                {
                    viewModel.ResponseCode = 6;
                    viewModel.Message = "学校信息不存在";
                }
            }
            catch (Exception ex)
            {
                viewModel.ResponseCode = 3;
                viewModel.Message = "出现异常";
            }

         
            return viewModel;
        }


        //根据 id 删除 教职工信息
        public BaseViewModel delFacultystaffInfo(int id)
        {
            BaseViewModel baseView = new BaseViewModel();
            facultystaff_Info info = _facultystaffInfoRepository.getbyID(id);
            if (info != null)
            {
                _facultystaffInfoRepository.RemoveInfo(info);
                int i = _facultystaffInfoRepository.SaveChanges();
                if (i > 0)
                {
                    baseView.ResponseCode = 0;
                    baseView.Message = "删除成功";
                }
                else
                {
                    baseView.ResponseCode = 1;
                    baseView.Message = "删除失败";
                }
            }
            else
            {
                baseView.ResponseCode = 1;
                baseView.Message = "删除失败";
            }
            return baseView;
        }


        //修改 教职工信息
        public BaseViewModel updateFacultystafffo(FacultystaffMiddle  facultystaff)
        {
            BaseViewModel baseView = new BaseViewModel();
            var info = _IMapper.Map<FacultystaffMiddle, facultystaff_Info>(facultystaff);
            _facultystaffInfoRepository.Update(info);
            int i = _facultystaffInfoRepository.SaveChanges();
            if (i > 0)
            {
                baseView.ResponseCode = 0;
                baseView.Message = "修改成功";
            }
            else
            {
                baseView.ResponseCode = 1;
                baseView.Message = "修改失败";
            }
            return baseView;
        }


        //根据条件查询
        public List<FacultystaffMiddle> GetListByParas(FacultystaffSearchModel model)
        {
            List<facultystaff_Info> lists = new List<facultystaff_Info>();
            List<FacultystaffMiddle> nlists = new List<FacultystaffMiddle>();
            if (!string.IsNullOrEmpty(model.IdNumber))
            {
                model.IdNumber = Dtol.Helper.MD5.Md5Hash(model.IdNumber);
            }

            lists = _facultystaffInfoRepository.GetByModel(model);

            foreach (var item in lists)
            {
                var info = _IMapper.Map<facultystaff_Info, FacultystaffMiddle>(item);

                info.IdNumber = Dtol.Helper.MD5.Decrypt(info.IdNumber);
                nlists.Add(info);
            }

            return nlists;
        }

        public void AddRelateToClass(AddRelateFromStaffToClassViewModel model)
        {
            var insert = _IMapper.Map<AddRelateFromStaffToClassViewModel, ClassManager_Relate>(model);
            staffClassRelateRepository.Add(insert);
            staffClassRelateRepository.SaveChanges();
        }

        public void DeleteRelateToClass(DeleteRelateFromStaffToClassViewModel model)
        {
            staffClassRelateRepository.RemoveByid(model.DeleteIdList);
            staffClassRelateRepository.SaveChanges();
        }

        public List<StaffClassMiddleModel> GetRelateToClassInfo(StaffClassRelateSearchViewModel staffClassRelateSearchView)
        {
            var searchResult = staffClassRelateRepository.GetStudentsByStaff(staffClassRelateSearchView);
            var result = _IMapper.Map<List<Health_Info>, List<StaffClassMiddleModel>>(searchResult);
            return result;
        }

       



    }
}
