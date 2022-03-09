using DietProject.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{
    public class MessagesValidation : AbstractValidator<Message>
    {
        public MessagesValidation()
        {
            RuleFor(x=>x.MessageDate)
                .NotNull().WithMessage("Tarih alanı boş bırakılamaz.");

            //RuleFor(x => x.IsReaded);

            RuleFor(x => x.MessageText.Trim())
                .NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.")
                .MinimumLength(0).WithMessage("Mesaj yazınız.");
        }
    }
}
