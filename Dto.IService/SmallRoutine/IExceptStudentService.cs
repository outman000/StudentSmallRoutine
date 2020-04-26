using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IExceptStudentService
    {
        void addExceptStudentAddService(ExceptStudentAddViewModel exceptStudentAddViewModel);
        void updateExceptStudentUpdateServide(ExceptStudentUpdateViewModel exceptStudentUpdateViewModel);
        void SearchExceptStudengDeleteService(List<int> deleteList);
        List<ExceptStudentSearchMiddle> SearchExceptStudengSearchService(ExceptStudengSearchInfoVIewModel exceptStudentSearchInfoVIewModel);
    }
}
