using DietProject.Core.ExtensionEF;
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
                .LessThanOrEqualTo(50).WithMessage("Boyunuzu en az 50 cm olarak seçebilirsiniz.");

            RuleFor(x => x.Height)
                .NotNull().WithMessage("Boy kısmı boş olamaz.");

            RuleFor(x => x.BirthDate)
                .NotNull().WithMessage("Doğum tarihi kısmı boş olamaz.")
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Doğum tarihiniz bugünden büyük olamaz.");

            RuleFor(x => x.AllergenicFood)
               .NotNull().WithMessage("Alerjik besinler kısmı boş olamaz.");
        }
    }
}
