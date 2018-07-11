using System.Collections.Generic;

namespace DAL
{
    public enum ClassesOfCar { For4Person, For8Person, ForVantazh }

    public class Car
    {
        public Car()
        {
            Drivers = new List<Driver>();
        }
        public int Id { get; set; }
        public ClassesOfCar ClassOfCar { get; set; }
        public string Marka { get; set; }
        public int Volume { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
