using DietProject.Core.Entities;
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
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Adınız en az 2 karakterden oluşmalıdır.");

            RuleFor(x => x.EPosta)
                .NotEmpty().WithMessage("E-Posta alanı boş bırakılamaz.")
                .MinimumLength(5).WithMessage("E-posta alanı yetersiz.")
                .EmailAddress().WithMessage("E-Posta formatınız doğru değil.");

            //RuleFor(x => x.IsActive)
            //    .NotEmpty().WithMessage("Aktiflik alanı boş bırakılamaz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifre alanı 8 karakterden fazla olmalıdır.");
        }
    }
}
