using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Interfaces
{
    public interface IError
    {
        string FieldName { get; set; }
        string ErrorMessage { get; set; }
    }
}
