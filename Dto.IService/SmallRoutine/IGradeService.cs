using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IGradeService
    {
        List<GradeInfoSearchMiddleModel> GetGradeKey(String Code);
    }
}
