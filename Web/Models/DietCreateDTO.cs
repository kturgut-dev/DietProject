using System;

namespace Web.Models
{
    public class DietCreateDTO
    {
        public DateTime CreatedDate { get; set; }
        public Int64[] Foods { get; set; }
        public Int64[] MeasureUnit { get; set; }
        public int[] Quantity { get; set; }
        public string[] MealType { get; set; }
    }
}
