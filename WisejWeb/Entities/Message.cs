using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.WisejWeb.Entities
{
    public class Message : BaseEntity
    {
    
        public DateTime MessageDate { get; set; }
        public bool IsReaded { get; set; }
        public string MessageText { get; set; }
        public Int64 SendedUserID { get; set; }
        public Int64 ReceiverUserID { get; set; }
    }
}
