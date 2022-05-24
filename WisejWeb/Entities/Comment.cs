using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Entities
{
    public class Comment: BaseEntity
    {
       
        public Int64 DietitianID { get; set; }
        public Int64 CustomerID { get; set; }
        public int Score { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
