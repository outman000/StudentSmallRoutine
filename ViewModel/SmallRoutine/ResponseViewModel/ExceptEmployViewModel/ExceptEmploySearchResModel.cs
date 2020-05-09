using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.ExceptEmployViewModel
{
   public  class ExceptEmploySearchResModel
    {

        public List<ExceptEmploySearchMiddle>  exceptEmploySearchMiddles;
        public ExceptEmploySearchResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
