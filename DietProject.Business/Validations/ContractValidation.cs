using DietProject.Core.ExtensionEF;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Business.Validations
{

    public class ContractValidation : AbstractValidator<Contract>
    {
        public ContractValidation()
        {
            RuleFor(x => x.ContractStartDate)
                    .NotNull().WithMessage("Anlaşma oluştulabilmesi için başlangıç tarihi girmek zorunludur.")
           .LessThanOrEqualTo(DateTime.Now).WithMessage("Yapılan anlaşma bugünden küçük olamaz");

            RuleFor(x => x.ContractEndDate)
                   .NotNull().WithMessage("Anlaşma oluşturulabilmesi için bitiş tarihi girmek zorunludur.");

            RuleFor(x => x.ContractPrice)
                  .NotNull().WithMessage("Anlaşma oluşturulabilmesi için ücret belirtmek zorunludur.")
                  .LessThanOrEqualTo(1).WithMessage("Sözleşme tutarı en az 1₺ olmalıdır.");
        }
    }
}
