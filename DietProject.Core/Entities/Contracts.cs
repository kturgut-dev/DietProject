using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    class Contracts
    {
        public Int64 ID { get; set; }
        public Int64 CustomerID { get; set; }
        public Int64 DietitanID { get; set; }
        public float ContractPrice { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
    }
}
