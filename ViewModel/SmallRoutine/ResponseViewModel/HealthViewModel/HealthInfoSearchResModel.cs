﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.HealthViewModel
{
    public class HealthInfoSearchResModel
    {
        public bool IsSuccess;
        public List<HealthInfoSearchMiddle>  healthInfoSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public HealthInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
