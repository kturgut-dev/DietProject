using DietProject.Core.ExtensionEF;
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

            RuleFor(x => x.IsReaded);

            RuleFor(x => x.MessageText)
                .NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz.")
                .Length(0).WithMessage("Mesaj yazınız.");
        }
    }
}
