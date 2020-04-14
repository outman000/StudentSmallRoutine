using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.PublicViewModel
{
    /// <summary>
    /// 页码属性
    /// </summary>
    public class PageViewModel
    {
        /// <summary>
        /// 是否需要分页
        /// </summary>
        public  bool needpage;
        /// <summary>
        /// 篇幅
        /// </summary>
        public int PageSize;
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPageNum;
    }
}
