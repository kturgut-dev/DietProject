using DietProject.Core.Entities;
using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class DietDetailDTO
    {
        public string DayName { get; set; }
        public DateTime Date { get; set; }
    }

    public class DietDetailViewData
    {
        public User UserData { get; set; }
        public Customer CustomerData { get; set; }
        public List<DietDetailDTO> DietDetailData { get; set; }
        public DietDetailViewData()
        {
            DietDetailData = new List<DietDetailDTO>();
        }
    }
}
