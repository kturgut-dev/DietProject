using DietProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Meeting : BaseEntity
    {
        public Int64 DietitianID { get; set; }
        public DateTime SelectedDate { get; set; }
        public Int64 CustomerID { get; set; }
    }
}
