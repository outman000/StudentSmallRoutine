using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;

namespace Dto.Service.SmallRoutine
{
    public   class ExceptEmployService: IExceptEmployService
    {
        private readonly IExceptEmployRepository  exceptEmployRepository;
        private readonly IFacultystaffService  facultystaffService;
        private readonly IFacultystaffInfoRepository  facultystaffInfoRepository;
        private readonly IMapper _IMapper;

        public ExceptEmployService(IExceptEmployRepository exceptEmployRepository, IFacultystaffService facultystaffService, IFacultystaffInfoRepository facultystaffInfoRepository, IMapper iMapper)
        {
            this.exceptEmployRepository = exceptEmployRepository;
            this.facultystaffService = facultystaffService;
            this.facultystaffInfoRepository = facultystaffInfoRepository;
            _IMapper = iMapper;
        }


        //Except_Info_Employ
        public void addExceptEmployService(ExceptEmployAddViewModel exceptEmployAddViewModel)
        {

            var insertmodel= _IMapper.Map<ExceptEmployAddViewModel, Except_Info_Employ>(exceptEmployAddViewModel);
            var employinfo = facultystaffInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(exceptEmployAddViewModel.Idnumber));
            insertmodel.facultystaff_InfoId = employinfo.id;
            exceptEmployRepository.Add(insertmodel);
            exceptEmployRepository.SaveChanges();
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
    }
}
