using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public Int64 ID { get; set; }
    }
}
