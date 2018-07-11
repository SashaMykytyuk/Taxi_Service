using System.Collections.Generic;
namespace DAL
{
    public class Location
    {
        public Location()
        {
            Drivers = new List<Driver>();
        }
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Place { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
