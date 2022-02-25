using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class Users
    {
        public Int64 ID { get; set; }
        public string FullName { get; set; }
        public string EPosta { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }

    }
}
