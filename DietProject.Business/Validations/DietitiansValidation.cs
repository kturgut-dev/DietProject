using System;
using DietProject.Core.ExtensionEF;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class DietitiansValidation : AbstractValidator<Dietitian>
    {
        public DietitiansValidation()
        {
            RuleFor(x => x.IsCertificate).NotEmpty();

            RuleFor(x => x.IsCertificateVerDate).NotEmpty();

            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz.");

            RuleFor(x => x.MonthlyPrice)
                .NotNull().WithMessage("Aylık ücret boş bırakılamaz.")
                .LessThan(1).WithMessage("Aylık ücret 1den küçük olamaz.");
        }
    }
}
