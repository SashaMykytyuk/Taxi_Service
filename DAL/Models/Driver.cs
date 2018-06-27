using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Driver : AbstractPerson
    {
        public Location Location { get; set; }
        public double Money { get; set; }
        public double KM { get; set; }
        public Car Car { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
