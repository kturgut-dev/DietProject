using Core.Entities.Abstract;
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
        public Int64 UserID { get; set; } // diyetisyense diyetisyen musterıyse musterı ıd
        public string DietitianName { get; set; }
        public string Avatar { get; set; }
        public string Bio { get; set; }
    }
    public class Calender
    {
        [Newtonsoft.Json.JsonProperty("id")]
        public string Id { get; set; }
        [Newtonsoft.Json.JsonProperty("description")]
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string date { get { return StartDate.ToString("MM-dd-yyyy"); }  }
        public bool AllDay { get; set; } = true;
        public bool everyYear { get; set; } = true;
        public string color { get; set; } = "#63d867";
        public string type { get; set; } = "birthday";
    }
    public class HomeViewData
    {
        public List<Slider> Sliders { get; set; }
        public List<ContractDietitians> PopulerDietitians { get; set; }
        public List<ContractDietitians> Customers { get; set; }
        public List<Calender> Calender { get; set; }
        public List<DietitianViewData> DietitianView { get; set; }
        public HomeViewData()
        {
            Sliders = new List<Slider>();
            Customers = new List<ContractDietitians>();
            Calender = new List<Calender>();
            PopulerDietitians = new List<ContractDietitians>();
        }
    }
}
