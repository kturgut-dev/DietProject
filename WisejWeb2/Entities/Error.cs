using DietProject.WisejWeb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Entities
{
    public class Error : IError
    {
        public string FieldName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
