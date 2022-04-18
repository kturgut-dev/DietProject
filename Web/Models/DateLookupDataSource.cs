using DietProject.Core.Entities;
using System.Collections.Generic;

namespace Web.Models
{
    public class DateLookupDataSource
    {
        public List<LookupEditDataSource> Days { get; set; }
        public List<LookupEditDataSource> Months { get; set; }
        public List<LookupEditDataSource> Years { get; set; }
        public Customer CustomerData { get; set; }
        public DateLookupDataSource()
        {
            Days = new List<LookupEditDataSource>();
            Months = new List<LookupEditDataSource>();
            Years = new List<LookupEditDataSource>();
        }
    }
}
