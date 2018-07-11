using System.Collections.Generic;
namespace DAL
{
    public class Client : AbstractPerson
    {
        public Client()
        {
            Orders = new List<Order>();
        }
        public ICollection<Order> Orders { get; set; }
    }
}
