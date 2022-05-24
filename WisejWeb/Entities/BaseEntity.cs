using System;
using System.ComponentModel.DataAnnotations;

namespace DietProject.WisejWeb.Entities
{
    public class BaseEntity
    {
        [Key]
        public Int64 ID { get; set; }
    }
}
