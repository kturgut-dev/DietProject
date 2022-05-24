using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DietProject.WisejWeb.Entities
{
    public class Contract : BaseEntity
    {
        public bool IsApproved { get; set; }
        public Int64 CustomerID { get; set; }
        public Int64 DietitanID { get; set; }
        public float ContractPrice { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }

        [NotMapped]
        public Dietitian DietitianData { get; set; }
        [NotMapped]
        public User UserDietitianData { get; set; }
        [NotMapped]
        public User UserCustomerData { get; set; }
    }
}
