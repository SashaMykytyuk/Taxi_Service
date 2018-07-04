using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLDriver : Bll
    {
        public BLLDriver(IDAL dal) : base(dal) { }
        public Driver Authorization(string email, string password)
        {
            return _dal.Get<Driver>().FirstOrDefault(elem => elem.Email == email && elem.Password == password);
        }
        public ICollection<Car> GetAllCars()
        {
            return _dal.Get<Car>();
        }
        public string CreateReport(int idDriver)
        {
            Driver driver = _dal.Get<Driver>().FirstOrDefault(elem => elem.Id == idDriver);
            if (driver == null)
                return "Choose driver";
            if (driver.Money == 0)
                return "You don't need crete report. Your salary today is zero";
            Report report = new Report();
            report.Driver = driver;
            report.Date = DateTime.Now;
            report.KM = driver.KM;
            report.Money = driver.Money;
            driver.KM = 0;
            driver.Money = 0;

            try
            {
                _dal.Create<Report>(report);
                _dal.ChangeDriver(driver.Id, driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public string SetLocation(int idDriver, Location location)
        {
            Driver driver = _dal.Get<Driver>().FirstOrDefault(elem => elem.Id == idDriver);

            if (driver == null)
                return "Choose driver";
            driver.Location = location;
            try
            {
                _dal.ChangeDriverLocation(driver.Id, driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string CreateCar(Car car)
        {
            try
            {
                car.Marka = GenericParams.SetName(car.Marka);
            }
            catch (ArgumentNullException)
            {
                return "Input marka of car";
            }
            if (car.Volume <= 0)
                return "Input correct Volume";
            if (car.Age < 0)
                return "Input correct age of car";
            try
            {
                _dal.Create<Car>(car);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ChangeCar(int idDriver, int idCar)
        {
            try
            {
                Driver driver = _dal.Get<Driver>().FirstOrDefault(elem => elem.Id == idDriver);
                Car car = _dal.Get<Car>().FirstOrDefault(elem => elem.Id == idCar);
                driver.Car = car;
                _dal.ChangeDriver(driver.Id, driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public ICollection<Order> GetOrders(int idDriver)
        {
            return _dal.Get<Order>().Where(elem => elem.Driver.Id == idDriver).ToList();
        }
        public ICollection<Report> GetReports(int idDriver)
        {
            return _dal.Get<Report>().Where(elem => elem.Driver.Id == idDriver).ToList();
        }
        public string ChangeInfo(int idDriver, Changes change, string param)
        {
            Driver driver = _dal.Get<Driver>().FirstOrDefault(elem => elem.Id == idDriver);
            if (driver == null)
                return "Wrong person!!!";
            switch (change)
            {
                case Changes.Email:
                    try
                    {
                        driver.Email = GenericParams.SetEmail(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input email";
                    }
                    break;
                case Changes.FirstName:
                    try
                    {
                        driver.FirstName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input First name";
                    }
                    break;
                case Changes.SecondName:
                    try
                    {
                        driver.SecondName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input Second name";
                    }
                    break;
                case Changes.Password:
                    try
                    {
                        driver.Password = GenericParams.SetPassword(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input password";
                    }
                    catch (FormatException)
                    {
                        return "Your password must contain as least 8 symvols, digits and big letters";
                    }
                    break;
            }
            try
            {
                _dal.ChangeDriver(driver.Id, driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
