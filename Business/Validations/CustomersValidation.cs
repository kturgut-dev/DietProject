using DietProject.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Weight)
                .NotNull().WithMessage("Kilo kısmı boş olamaz.")
                .LessThanOrEqualTo(25).WithMessage("Kilonuz en az 25 kg olarak seçebilirsiniz.");

            RuleFor(x => x.Height)
                .NotNull().WithMessage("Boy kısmı boş olamaz.")
                .LessThanOrEqualTo(50).WithMessage("Boyunuz en az 50cm olmalıdır.");

            RuleFor(x => x.BirthYear)
                .GreaterThanOrEqualTo(DateTime.Today.AddYears(-10).Year).WithMessage("10 yaşından küçük danışanlar kabul edilmemektedir.");

            RuleFor(x => x.AllergenicFood)
               .NotEmpty().WithMessage("Alerjik besinler kısmı boş olamaz.")
               .NotNull().WithMessage("Alerjik besinler kısmı boş olamaz.")
               .MinimumLength(2).WithMessage("Alerjik besinler kısmı en az 2 karakter olmalıdır.")
               .MaximumLength(500).WithMessage("Alerjik besinler kısmı en fazla 500 karakter olmalıdır.");
        }
    }
}
