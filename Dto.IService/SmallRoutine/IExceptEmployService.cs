using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IExceptEmployService
    {
        void addExceptEmployService(ExceptEmployAddViewModel exceptEmployAddViewModel);
        void updateExceptEmployService(ExceptEmployUpdateViewModel exceptEmployUpdateViewModel);
        void deleteExceptEmployService(List<int> deleteList);
        List<ExceptEmploySearchMiddle> searchExceptEmployService(ExceptEmploySearchViewModel exceptEmploySearchViewModel);
    }
}
