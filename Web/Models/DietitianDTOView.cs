using Core.Entities.Abstract;
using DietProject.Core.Entities;
using System.Collections.Generic;

namespace Web.Models
{
    public class DietitianDTOView: DietitianDTO
    {
        public List<ContractDietitians> Customers { get; set; }
        public List<Calender> Calender { get; set; }
        public List<User> AllCustomers { get; set; }
        public bool IsUserOwner { get; set; }//kendı profılınde mı
        public DietitianDTOView()
        {
            Customers = new List<ContractDietitians>();
            Calender = new List<Calender>();
            AllCustomers = new List<User>();
        }
    }
}
