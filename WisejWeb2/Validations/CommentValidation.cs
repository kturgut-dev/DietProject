using DietProject.WisejWeb.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Validations
{
    //https://docs.fluentvalidation.net/en/latest/
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Score)
                .NotNull().WithMessage("Skor belirlemeniz gerekmektedir.")
                .LessThanOrEqualTo(0).WithMessage("Skorunuz 0'dan büyük olmalıdır.");

            RuleFor(x => x.CommentText)
                .NotEmpty().WithMessage("Yorum girmek zorunludur.");

            RuleFor(x => x.CommentDate)
                .NotNull().WithMessage("Yorum tarihi boş olamaz.");
        }
    }
}
