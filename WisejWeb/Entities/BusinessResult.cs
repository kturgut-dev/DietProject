using DietProject.WisejWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Entities
{
    public class BusinessResult<T> : IBusinessResult<T>
    {
        public T Result { get; set; }
        public ErrorTypes ErrorType { get; set; }
        public List<IError> Errors { get; set; }
    }
}
