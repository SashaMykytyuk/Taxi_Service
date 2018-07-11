using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Price
    {
        public int Id { get; set; }
        public ClassesOfCar ClassOfCar { get; set; }
        public double Money { get; set; }
    }
}
