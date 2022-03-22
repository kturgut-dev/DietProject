using System;

namespace Web.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public Int64 population { get; set; }
        public string region { get; set; }
    }
}
