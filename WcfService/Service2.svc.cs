using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BLL;
using DAL;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service2 : IServiceDriver
    {
        public BLLDriver DriverBll = new BLLDriver(new Dal(new TaxiContext()));

        Driver driver;

        public Driver AboutDriver()
        {
            return new Driver()
            {
                SecondName = driver.SecondName,
                Password = driver.Password,
                Email = driver.Email,
                FirstName = driver.FirstName,
                Location = new Location() { Place = driver.Location.Place },
                Car = new Car() { Id = driver.Car.Id, Age = driver.Car.Age, ClassOfCar = driver.Car.ClassOfCar, Marka = driver.Car.Marka, Volume = driver.Car.Volume }
            };
        }

        public ICollection<Car> AllCars()
        {
            return DriverBll.GetAllCars();
        }

        public ICollection<Order> AllOrders()
        {
            return DriverBll.GetOrders(driver.Id);
        }

        public ICollection<Report> AllReports()
        {
            return DriverBll.GetReports(driver.Id);
        }

        public string Authorization(string Email, string Password)
        {
            driver = DriverBll.Authorization(Email, Password);
            if (driver == null)
                return "Wrong password or email";
            return "";
        }

        public string ChangeCar(int idCar)
        {
            return DriverBll.ChangeCar(driver.Id, idCar);
        }

        public string ChangeInfo(Changes changes, string param)
        {
            return DriverBll.ChangeInfo(driver.Id, changes, param);
        }

        public string CreateReport()
        {
            return DriverBll.CreateReport(driver.Id);
        }

        public void LogOut()
        {
            driver = null;
        }

        public string MyPosition(Location location)
        {
            return DriverBll.SetLocation(driver.Id, location);
        }

        public string WriteToDispatcher(string Title, string Message)
        {
            if (DriverBll.SendMessageToDispatcher(driver, Title, Message) == true)
                return "Message is send";
            else return "Something wrong.Message is not send";
        }
    }



}
