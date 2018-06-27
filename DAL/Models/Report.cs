using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Driver Driver { get; set; }
        public double Money { get; set; }
        public double KM { get; set; }
    }
}
