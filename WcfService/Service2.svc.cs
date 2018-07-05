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
                Car = new Car() { Age = driver.Car.Age, ClassOfCar = driver.Car.ClassOfCar, Marka = driver.Car.Marka, Volume = driver.Car.Volume }
            };
        }

        public string Authorization(string Email, string Password)
        {
            driver = DriverBll.Authorization(Email, Password);
            if (driver == null)
                return "Wrong password or email";
            return "";
        }
    }



}
