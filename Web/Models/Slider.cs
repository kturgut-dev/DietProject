using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class Slider
    {
        public string ImageUrl { get; set; }
        public string Text { get; set; }
    }

    public class ContractDietitians
    {
        public Int64 DietitianID { get; set; }
        public string DietitianName { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
    }
    public class Calender
    {
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllDay { get; set; } = true;
    }
    public class HomeViewData
    {
        public List<Slider> Sliders { get; set; }
        public List<ContractDietitians> PopulerDietitians { get; set; }
        public List<ContractDietitians> Dietitians { get; set; }
        public List<Calender> Calender { get; set; }
        public HomeViewData()
        {
            Sliders = new List<Slider>();
            Dietitians = new List<ContractDietitians>();
            Calender = new List<Calender>();
            PopulerDietitians = new List<ContractDietitians>();
        }
    }
}
