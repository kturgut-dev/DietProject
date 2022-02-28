using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    class Customers
    {
        public Int64 ID { get; set; }
        public Int64 UserID { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public DateTime BirthDate { get; set; }
        public string AllergenicFood { get; set; }
    }
}
