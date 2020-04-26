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

        public ExceptStudentService(IExceptStudentRepository exceptStudentRepository, IMapper iMapper)
        {
            this.exceptStudentRepository = exceptStudentRepository;
            _IMapper = iMapper;
        }

        public void addExceptStudentAddService(ExceptStudentAddViewModel exceptStudentAddViewModel)
        {
            var  insertmodel= _IMapper.Map<ExceptStudentAddViewModel, Except_Info_Student>(exceptStudentAddViewModel);
            
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
         var result=  exceptStudentRepository.searchByemploytoclass(exceptStudentSearchInfoVIewModel);

            return null; 
        }

        public void updateExceptStudentUpdateServide(ExceptStudentUpdateViewModel exceptStudentUpdateViewModel)
        {
            var updatemodel = _IMapper.Map<ExceptStudentUpdateViewModel, Except_Info_Student>(exceptStudentUpdateViewModel);
            exceptStudentRepository.Update(updatemodel);
            exceptStudentRepository.SaveChanges();
        }
    }
}
