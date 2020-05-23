using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.FileViewModel
{
    public class FileSearchResModel
    {
        public List<FIleinfoMiddle>  fIleinfoMiddles;

        public FileSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
