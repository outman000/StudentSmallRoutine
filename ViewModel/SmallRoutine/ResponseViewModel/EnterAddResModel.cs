﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
     public  class EnterAddResModel
    {
        public EnterAddResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public int AddCount;
        public BaseViewModel baseViewModel;
    }
}
