using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Entities
{
    public class DietDetail : BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public bool IsCompleted { get; set; }
        public Int64 ContractID { get; set; }
        public Int64 FoodID { get; set; }
        public Int64 MeasureUnitID { get; set; }
        public string MealType { get; set; }
        //public string MeasureUnit { get; set; }
        public float Quantity { get; set; }
        public Int64 CustomerID { get; set; }
        public Int64 DietitianID { get; set; }
    }
}
