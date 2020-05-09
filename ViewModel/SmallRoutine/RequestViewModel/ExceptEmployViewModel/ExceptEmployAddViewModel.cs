﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel
{
    public class ExceptEmployAddViewModel
    {

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }//体温



        /// <summary>
        /// 图片信息主键
        /// </summary>
        public int? UserFiles_InfoId { get; set; }
    }
}
