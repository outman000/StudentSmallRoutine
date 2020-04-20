using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public class EditPwdViewModel
    {
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }

        /// 密码
        /// </summary>
        public string OldPassword { get; set; }
        /// 密码
        /// </summary>
        public string NewPassword { get; set; }
    }
}
