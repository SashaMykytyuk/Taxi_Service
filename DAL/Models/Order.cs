namespace DAL
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Location LocationFrom { get; set; }
        public virtual Location LocationTo { get; set; }
        public ClassesOfCar ClassOfCar { get; set; }
        public virtual Driver Driver { get; set; }
        public string Comment { get; set; }
        public bool Done { get; set; } 
        public int KM { get; set; }
        public int Money { get; set; }
    }
}
