using System.Collections.Generic;
namespace DAL
{
    public class Location
    {
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
