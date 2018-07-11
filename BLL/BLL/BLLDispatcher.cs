﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BLL
{
    public class BLLDispatcher : Bll
    {
        public BLLDispatcher(IDAL dal) : base(dal) { }
        public Dispatcher Authorization(string email, string password)
        {
            return _dal.Get<Dispatcher>().FirstOrDefault(elem => elem.Email == email && elem.Password == password);
        }
        public string CreateDriver(Driver driver, int idCar)
        {
            Car car = _dal.Get<Car>().FirstOrDefault(elem => elem.Id == idCar);
            if (car == null)
                return "Choose car for driver";
            try
            {
                driver.FirstName = GenericParams.SetName(driver.FirstName);
            }
            catch (ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                driver.SecondName = GenericParams.SetName(driver.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                driver.Email = GenericParams.SetEmail(driver.Email);
            }
            catch (ArgumentNullException)
            {
                return "Input email";
            }
            catch (FormatException)
            {
                return "Wrong format email";
            }
            try
            {
                driver.Password = GenericParams.SetPassword(driver.Password);
            }
            catch (ArgumentNullException)
            {
                return "Input password";
            }
            catch (FormatException)
            {
                return "Your password must contain as least 8 symvols, digits and big letters";
            }
            driver.Car = car;
            driver.Money = 0;
            driver.KM = 0;
            try
            {
                _dal.Create<Driver>(driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string CreateDispatcher(Dispatcher dispatcher)
        {
            try
            {
                dispatcher.FirstName = GenericParams.SetName(dispatcher.FirstName);
            }
            catch (ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                dispatcher.SecondName = GenericParams.SetName(dispatcher.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                dispatcher.Email = GenericParams.SetEmail(dispatcher.Email);
            }
            catch (ArgumentNullException)
            {
                return "Input email";
            }
            catch (FormatException)
            {
                return "Wrong format email";
            }
            try
            {
                dispatcher.Password = GenericParams.SetPassword(dispatcher.Password);
            }
            catch (ArgumentNullException)
            {
                return "Input password";
            }
            catch (FormatException)
            {
                return "Your password must contain as least 8 symvols, digits and big letters";
            }
            try
            {
                _dal.Create<Dispatcher>(dispatcher);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public ICollection<Driver> GetAllDrivers()
        {
            List<Driver> drivers = new List<Driver>();
            foreach(var elem in _dal.Get<Driver>().ToList())
            {
                drivers.Add(new Driver()
                {
                    Id = elem.Id,
                    Email = elem.Email,
                    FirstName = elem.FirstName,
                    SecondName = elem.SecondName,
                    Car = new Car() {  Id = elem.Car.Id}
                });
            }
            return drivers;
        }
        public ICollection<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            foreach(var elem in _dal.Get<Client>())
            {
                clients.Add(new Client() { Id = elem.Id, Email = elem.Email, FirstName = elem.FirstName, SecondName = elem.SecondName});
            }
            return clients;
        }
        public ICollection<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            foreach(var elem in _dal.Get<Car>())
            {
                cars.Add(new Car() {Id = elem.Id, Age = elem.Age, ClassOfCar = elem.ClassOfCar, Marka = elem.Marka, Volume = elem.Volume });
            }
            return cars;
        }
        public ICollection<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();
            foreach (var elem in _dal.Get<Report>())
            {
                reports.Add(new Report() { Date = elem.Date, Id = elem.Id, KM = elem.KM, Money = elem.Money, Driver = new Driver() { FirstName = elem.Driver.FirstName, SecondName = elem.Driver.SecondName, Id = elem.Id } });
            }
            return reports;
        }
        public ICollection<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            foreach(var elem in _dal.Get<Order>())
            {
                orders.Add(new Order()
                {
                    ClassOfCar = elem.ClassOfCar,
                    Comment = elem.Comment,
                    Done = elem.Done,
                    KM = elem.KM,
                    Money = elem.Money,
                   // Client = new Client() { Id = elem.Id, FirstName = elem.Client.FirstName, SecondName = elem.Client.SecondName },
                   // Driver = new Driver() { Id = elem.Id, FirstName = elem.Driver.FirstName, SecondName = elem.Driver.SecondName },
                    Id = elem.Id,
                //    LocationFrom = new Location() { Lat = elem.LocationFrom.Lat, Lng = elem.LocationFrom.Lng, Place = elem.LocationFrom.Place },
                //    LocationTo = new Location() { Lat = elem.LocationTo.Lat, Lng = elem.LocationTo.Lng, Place = elem.LocationTo.Place }
                });
            }
            return orders;
        }
        public string ChangeDriverForOrder(int idOrder, int idDriver)
        {
            Order order = _dal.Get<Order>().FirstOrDefault(elem => elem.Id == idOrder);
            if (order == null)
                return "Choose order";
            if (order.Done == true)
                return "You can't change driver for order, Order is done";
            Driver driver = _dal.Get<Driver>().FirstOrDefault(elem => elem.Id == idDriver);
            if (driver == null)
                return "Choose driver";
            if(driver.Car.ClassOfCar != order.ClassOfCar)
            {
                order.ClassOfCar = driver.Car.ClassOfCar;
                order.Money = GetPrice(order.KM, order.ClassOfCar);
            }
            order.Driver = driver;
            driver.Location = null;
            try
            {
                _dal.ChangeOrder(order.Id, order);
                _dal.ChangeDriver(driver.Id, driver);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        } 
        public string OrderDone(int  IdOrder)
        {
            Order order = _dal.Get<Order>().FirstOrDefault(elem => elem.Id == IdOrder);
            if (order == null)
                return "Wrong order";
            if (order == null)
                return "Choose order";
            if (order.Done == true)
                return "";
            if(order.Driver == null) 
                return "Not choose driver";

            order.Driver.KM += order.KM;
            order.Driver.Money += order.Money;

            order.Done = true;

            try
            {
                _dal.ChangeDriver(order.Driver.Id, order.Driver);
                _dal.ChangeOrder(order.Id, order);
                return "";
            }

            catch(Exception ex)
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public string ChangeInfo(int idDispatcher, Changes change, string param)
        {
            Dispatcher dispatcher = _dal.Get<Dispatcher>().FirstOrDefault(elem => elem.Id == idDispatcher);
            if (dispatcher == null)
                return "Something wrong!!!";
            switch (change)
            {
                case Changes.Email:
                    try
                    {
                        dispatcher.Email = GenericParams.SetEmail(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input email";
                    }
                    break;
                case Changes.FirstName:
                    try
                    {
                        dispatcher.FirstName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input First name";
                    }
                    break;
                case Changes.SecondName:
                    try
                    {
                        dispatcher.SecondName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input Second name";
                    }
                    break;
                case Changes.Password:
                    try
                    {
                        dispatcher.Password = GenericParams.SetPassword(param);
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
                _dal.ChangeDispatcher(dispatcher.Id, dispatcher);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public void ChangePrice(ClassesOfCar classOfCar, double newPrice)
        {
            //_dal.ChangePrice()
        }
        private double GetPrice(double km, ClassesOfCar classes)
        {
            return _dal.Get<Price>().FirstOrDefault(elem => elem.ClassOfCar == classes).Money * km;
        }

    }
}