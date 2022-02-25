using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class Messages
    {
        public Int64 ID { get; set; }
        public DateTime MessageDate { get; set; }
        public bool IsReaded { get; set; }
        public string MessageText { get; set; }
        public Int64 SendedUserID { get; set; }
        public Int64 ReceiverUserID { get; set; }
    }
}
