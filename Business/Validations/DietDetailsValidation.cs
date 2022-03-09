using DietProject.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class DietDetailsValidation : AbstractValidator<DietDetail>
    {
        public DietDetailsValidation()
        {
            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage("Diyet tarihlerini belirtmeniz gerekmektedir.");

            RuleFor(x => x.MealType)
                .NotEmpty().WithMessage("Hangi öğün olduğunu girmek zorunludur.")
                .NotNull().WithMessage("Hangi öğün olduğunu girmek zorunludur.")
                .MinimumLength(3).WithMessage("Öğün en az 3 karakter olmalıdır.");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Birim belirtilmesi gereklidir.")
                .LessThanOrEqualTo(0).WithMessage("Birim miktarı 0'dan büyük olmalıdır.");

            //RuleFor(x => x.MeasureUnitId)
            //    .NotNull().WithMessage("Birim tipi seçilmesi gereklidir.");
        }
    }
}
