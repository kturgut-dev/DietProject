using DietProject.Core.ExtensionEF;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class UsersValidation : AbstractValidator<User>
    {
        public UsersValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.").Length(2);

            RuleFor(x => x.EPosta)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                .Length(10).WithMessage("E-posta alanı yetersiz.");

            RuleFor(x => x.IsActive)
                .NotEmpty().WithMessage("Aktiflik alanı boş bırakılamaz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
                .Length(8).WithMessage("Şifre alanı 8 karahterden fazla olmalıdır.");
        }
    }
}
