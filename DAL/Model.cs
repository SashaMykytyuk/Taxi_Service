namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TaxiContext : DbContext
    {
     
        public TaxiContext()
            : base("name=Model")
        {
            Database.SetInitializer<TaxiContext>(new CustomInit<TaxiContext>());   
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Dispatcher> Dispatchers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
    }
}