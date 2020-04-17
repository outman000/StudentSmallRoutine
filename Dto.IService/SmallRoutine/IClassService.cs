using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace Dto.IService.SmallRoutine
{
    public interface IClassService
    {
        List<ClassInfoSearchMiddleModel> GetClassKey(String Code);
    }
}
