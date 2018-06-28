using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Location LocationFrom { get; set; }
        public Location LocationTo { get; set; }
        public ClassesOfCar ClassOfCar { get; set; }
        public Driver Driver { get; set; }
        public string Comment { get; set; }
        public bool Done { get; set; } //?
    }
}
