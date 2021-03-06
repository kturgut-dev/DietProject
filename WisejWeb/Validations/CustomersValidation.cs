using DietProject.WisejWeb.Entities;
using FluentValidation;
using System;

namespace DietProject.WisejWeb.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Weight)
                .NotNull().WithMessage("Kilo kısmı boş olamaz.")
                .GreaterThanOrEqualTo(25).WithMessage("Kilonuz en az 25 kg olarak seçebilirsiniz.");

            RuleFor(x => x.Height)
                .NotNull().WithMessage("Boy kısmı boş olamaz.")
                .GreaterThanOrEqualTo(50).WithMessage("Boyunuz en az 50cm olmalıdır.");

            RuleFor(x => x.BirthDay)
           .NotNull().WithMessage("Ay seçmeniz gerekmektedir.");

            RuleFor(x => x.BirthMonth)
   .NotNull().WithMessage("Ay seçmeniz gerekmektedir.");


            RuleFor(x => x.BirthYear)
                .LessThanOrEqualTo(DateTime.Today.AddYears(-10).Year).WithMessage("10 yaşından küçük danışanlar kabul edilmemektedir.");

            RuleFor(x => x.Goal)
   .NotEmpty().WithMessage("Hedefinizi seçiniz.");

            RuleFor(x => x.AllergenicFood)
               .NotEmpty().WithMessage("Alerjik besinler kısmı boş olamaz.")
               .MinimumLength(2).WithMessage("Alerjik besinler kısmı en az 2 karakter olmalıdır.")
               .MaximumLength(500).WithMessage("Alerjik besinler kısmı en fazla 500 karakter olmalıdır.");
        }
    }
}
