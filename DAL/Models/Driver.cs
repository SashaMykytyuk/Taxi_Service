using System.Collections.Generic;

namespace DAL
{
    public class Driver : AbstractPerson
    {
        public virtual Location Location { get; set; }
        public double Money { get; set; }
        public double KM { get; set; }
        public virtual Car Car { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
