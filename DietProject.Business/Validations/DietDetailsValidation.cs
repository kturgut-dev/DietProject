using DietProject.Core.ExtensionEF;
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
                .NotEmpty().WithMessage("Hangi öğün olduğunu girmek zorunludur.");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Birim belirtilmesi gereklidir.");

        }
    }
}
