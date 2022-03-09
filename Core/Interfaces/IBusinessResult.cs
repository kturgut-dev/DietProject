using DietProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Interfaces
{
    public interface IBusinessResult<T>
    {
        T Result { get; set; }
        ErrorTypes ErrorType { get; set; }
        List<IError> Errors { get; set; }
    }
}
