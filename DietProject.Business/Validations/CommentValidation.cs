using DietProject.Core.ExtensionEF;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    //https://docs.fluentvalidation.net/en/latest/
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Score)
                .NotEmpty().WithMessage("Skor belirlemeniz gerekmektedir.")
                .GreaterThanOrEqualTo(0).WithMessage("Skorunuz 0'dan büyük olmalıdır.");

            RuleFor(x => x.CommentText)
                .NotEmpty().WithMessage("Yorum girmek zorunludur.");

            RuleFor(x => x.CommentDate)
                .NotNull().WithMessage("Yorum tarihi boş olamaz.");
        }
    }
}
