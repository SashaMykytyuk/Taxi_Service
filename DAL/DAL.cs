using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public interface IDAL
    {
        void Create<T>(T _element) where T: class;
        void Delete<T>(T _element) where T: class;
        ICollection<T> Get<T>() where T : class;
        void Update<T>(T item) where T : class;
        void ChangeCar(int IdCar, Car car);
        void ChangeDriver(int IdDriver, Driver driver);
        void ChangeOrder(int IdOrder, Order order);
        void ChangeDispatcher(int IdDispatcher, Dispatcher dispatcher);
        void ChangeClient(int IdClient, Client client);
        void ChangeDriverLocation(int IdDriver, Driver driver);
    }


    public class Dal : IDAL
    {
        DbContext context;
        public Dal(DbContext _context)
        {
            context = _context;
        }

        public void Create<T>(T _element) where T : class
        {
            context.Set<T>().Add(_element);
            context.SaveChanges();
        }

        public void Delete<T>(T _element) where T : class
        {
            context.Set<T>().Remove(_element);
            context.SaveChanges();
        }

        public ICollection<T> Get<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public void Update<T>(T item) where T:class
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void ChangeCar(int IdCar, Car car)
        {
            (context as TaxiContext).Cars.First(elem => elem.Id == IdCar).Age = car.Age;
            (context as TaxiContext).Cars.First(elem => elem.Id == IdCar).ClassOfCar = car.ClassOfCar;
            (context as TaxiContext).Cars.First(elem => elem.Id == IdCar).Marka = car.Marka;
            (context as TaxiContext).Cars.First(elem => elem.Id == IdCar).Volume = car.Volume;
            context.SaveChanges();
        }

        public void ChangeClient(int IdClient, Client client)
        {
            (context as TaxiContext).Clients.First(elem => elem.Id == IdClient).Email = client.Email;
            (context as TaxiContext).Clients.First(elem => elem.Id == IdClient).FirstName = client.FirstName;
            (context as TaxiContext).Clients.First(elem => elem.Id == IdClient).Password = client.Password;
            (context as TaxiContext).Clients.First(elem => elem.Id == IdClient).SecondName = client.SecondName;
            context.SaveChanges();
        }

        public void ChangeDriver(int IdDriver, Driver driver)
        {
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).Email = driver.Email;
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).FirstName = driver.FirstName;
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).Password = driver.Password;
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).SecondName = driver.SecondName;
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).Location = driver.Location;
            context.SaveChanges();
        }

        public void ChangeDriverLocation(int IdDriver, Driver driver)
        {
            (context as TaxiContext).Drivers.First(elem => elem.Id == IdDriver).Location = driver.Location;
            context.SaveChanges();
        }

        public void ChangeOrder(int IdOrder, Order order)
        {
            (context as TaxiContext).Orders.First(elem => elem.Id == IdOrder).ClassOfCar = order.ClassOfCar;
            (context as TaxiContext).Orders.First(elem => elem.Id == IdOrder).Done = order.Done;
            (context as TaxiContext).Orders.First(elem => elem.Id == IdOrder).Driver = order.Driver;
            context.SaveChanges();
        }

        public void ChangeDispatcher(int IdDispatcher, Dispatcher dispatcher)
        {
            (context as TaxiContext).Dispatchers.First(elem => elem.Email == dispatcher.Email).Email = dispatcher.Email;
            (context as TaxiContext).Dispatchers.First(elem => elem.Email == dispatcher.Email).FirstName = dispatcher.FirstName;
            (context as TaxiContext).Dispatchers.First(elem => elem.Email == dispatcher.Email).Password = dispatcher.Password;
            (context as TaxiContext).Dispatchers.First(elem => elem.Email == dispatcher.Email).SecondName = dispatcher.SecondName;
            context.SaveChanges();
        }
    }
}
