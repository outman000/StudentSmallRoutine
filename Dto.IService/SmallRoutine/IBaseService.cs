using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.BaseControlViewModel;
using ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IBaseService
    {
        void structSystemInfo();
        void structUserInfo();
        GradeAndClassResModel getGradeAndClass(GradeAndClassSearchViewModel gradeAndClassSearchViewModel);
    }
}
