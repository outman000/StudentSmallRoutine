using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class ImageUploadResModel
    {
        public int key { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
       
        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseViewModel baseViewModel;
        public ImageUploadResModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
