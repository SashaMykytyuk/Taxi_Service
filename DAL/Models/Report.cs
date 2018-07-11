using System;

namespace DAL
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Driver Driver { get; set; }
        public double Money { get; set; }
        public double KM { get; set; }
    }
}
