using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Core.Entities
{
    public class Dietitian : BaseEntity
    {
    
        public Int64 UserID { get; set; }
        public bool IsCertificate { get; set; }
        public DateTime IsCertificateVerDate { get; set; }
        public string CityName { get; set; }
        public float MonthlyPrice { get; set; }
        public string CertificatePath { get; set; }
    }
}
