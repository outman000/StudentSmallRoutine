using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel;

namespace ViewModel.SmallRoutine.ViewValitor.SmallRoutine
{
    public class BaseValide : AbstractValidator<DayAndNightDeleteByFIlesViewModel>
    {
        public BaseValide()
        {
            RuleFor(a=>a.tag)
                .Length(1,50)
                 .NotNull()
                 .WithMessage("文件标签不能为空值")
             ;
        }
    }
}
