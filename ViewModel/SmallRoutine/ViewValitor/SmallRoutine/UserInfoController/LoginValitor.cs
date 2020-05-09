using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel;

namespace ViewModel.SmallRoutine.ViewValitor.SmallRoutine
{
    public class LoginValitor : AbstractValidator<LoginViewModel>
    {
        public LoginValitor()
        {
            //RuleFor(hr_info => hr_info.Idnumber)
            //     .NotNull()
            //     .Matches("^(\\d{6})(\\d{4})(\\d{2})(\\d{2})(\\d{3})([0-9]|X)$")
            //     .WithMessage("身份证格式不正确")
            // ;
            //RuleFor(hr_info => hr_info.Password).NotNull()
            //    .MinimumLength(1)
            //     .WithMessage("密码不能为空")
            // ;

        }
    }
}
