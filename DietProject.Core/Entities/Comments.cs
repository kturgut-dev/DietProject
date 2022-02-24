using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class Comments
    {
        public Int64 ID { get; set; }
        public Int64 DietitianID { get; set; }
        public Int64 CustomerID { get; set; }
        public int Score { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
