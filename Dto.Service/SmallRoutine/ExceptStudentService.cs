using AutoMapper;
using Dto.IRepository.SmallRoutine;
using Dto.IService.SmallRoutine;
using Dtol.dtol;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;

namespace Dto.Service.SmallRoutine
{
    public class ExceptStudentService: IExceptStudentService
    {
        private readonly IExceptStudentRepository  exceptStudentRepository;
        private readonly IStudentInfoRepository studentInfoRepository;

        private readonly IMapper _IMapper;

        public ExceptStudentService(IExceptStudentRepository exceptStudentRepository, IStudentInfoRepository studentInfoRepository, IMapper iMapper)
        {
            this.exceptStudentRepository = exceptStudentRepository;
            this.studentInfoRepository = studentInfoRepository;
            _IMapper = iMapper;
        }

        public void addExceptStudentAddService(ExceptStudentAddViewModel exceptStudentAddViewModel)
        {
            var  insertmodel= _IMapper.Map<ExceptStudentAddViewModel, Except_Info_Student>(exceptStudentAddViewModel);
            var studentInfo = studentInfoRepository.getByidNumber(Dtol.Helper.MD5.Md5Hash(exceptStudentAddViewModel.Idnumber));
        
                insertmodel.student_InfoId = studentInfo.id;
                exceptStudentRepository.Add(insertmodel);
                exceptStudentRepository.SaveChanges();
          
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
    }
}
