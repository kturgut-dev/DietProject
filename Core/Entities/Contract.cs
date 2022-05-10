using System;

namespace DietProject.Core.Entities
{
    public class Contract : BaseEntity
    {
        public Int64 CustomerID { get; set; }
        public Int64 DietitanID { get; set; }
        public float ContractPrice { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}
