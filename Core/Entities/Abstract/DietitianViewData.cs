using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Abstract
{
    public class DietitianViewData
    {
        public string Sehir { get; set; }
        public string MonthlyPrice { get; set; }
        [Key]
        public Int64 DietitianID { get; set; }
        public Int64 UserID { get; set; }
        public string EPosta { get; set; }
        public string FullName { get; set; }
        [NotMapped]
        public string ProfileImage { get; set; }
        public int CommentCount { get; set; }
        public Int32 ScoreAvg { get; set; }
        public int ActiveCustomer { get; set; }
        public string ShortBio { get; set; }
    }
}
