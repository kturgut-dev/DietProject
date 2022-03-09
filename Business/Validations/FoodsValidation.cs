using DietProject.Core.Entities;
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
                .NotEmpty().WithMessage("Kayıt oluşuturan tanımlaması gereklidir.");

            RuleFor(x => x.CreatedDate)
                .NotNull().WithMessage("Tarih alanı boş bırakılamaz.");

            RuleFor(x => x.FoodName)
                .NotEmpty().WithMessage("Yemek adı girmeniz gerekmektedir.")
                .NotNull().WithMessage("Yemek adı girmeniz gerekmektedir.")
                .MinimumLength(2).WithMessage("Karakter sayısı 2 den fazla olmalıdır.");
        }
    }
}
