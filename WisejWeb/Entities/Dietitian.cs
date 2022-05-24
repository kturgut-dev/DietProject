using System;

namespace DietProject.WisejWeb.Entities
{
    public class Dietitian : BaseEntity
    {
        public Int64 UserID { get; set; }
        public bool IsCertificate { get; set; }
        public DateTime? IsCertificateVerDate { get; set; }
        public string CityName { get; set; }
        public double? MonthlyPrice { get; set; }
        public string CertificatePath { get; set; }
        public string Bio { get; set; }

    }
}
