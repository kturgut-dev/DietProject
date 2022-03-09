using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class Food : BaseEntity
    {

        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FoodName { get; set; }
    }
}
