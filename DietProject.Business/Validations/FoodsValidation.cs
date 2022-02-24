using DietProject.Core.ExtensionEF;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class FoodsValidation : AbstractValidator<Food>
    {
        public FoodsValidation()
        {
            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("");

            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage("Tarih alanı boş bırakılamaz.");

            RuleFor(x => x.FoodName)
                .NotNull().WithMessage("Skor belirlemeniz gerekmektedir.")
                .Length(2).WithMessage("Karakter sayısı 2 den fazla olmalıdır.");
        }
    }
}
