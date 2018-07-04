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
        public string CreateDriver(Driver driver, Car car)
        {
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
            return _dal.Get<Driver>();
        }
        public ICollection<Client> GetAllClients()
        {
            return _dal.Get<Client>();
        }
        public ICollection<Car> GetAllCars()
        {
            return _dal.Get<Car>();
        }
        public ICollection<Report> GetAllReports()
        {
            return _dal.Get<Report>();
        }
        public ICollection<Order> GetOrders()
        {
            return _dal.Get<Order>();
        }
        public string ChangeDriverForOrder(Order order, Driver driver)
        {
            if (order == null)
                return "Choose order";
            if (driver == null)
                return "Choose driver";
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
        public string OrderDone(Order order)
        {
            if (order == null)
                return "Choose order";
            if (order.Done == true)
                return "";
            if(order.Driver == null)
            {
                order.Done = true;
                return "";
            }

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
        public bool ChangeOrder(Order order)
        {
            try
            {
                _dal.ChangeOrder(order.Id, order);
                return true;
            }
            catch { return false; }
        }
        public string ChangeInfo(Dispatcher dispatcher, Changes change, string param)
        {
            if (dispatcher == null)
                return "Authorization!!!";
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
        public void Clear()
        {
            foreach (var elem in _dal.Get<Location>().Where(elem => elem.Drivers == null))
                _dal.Delete<Location>(elem);
        }
    }
}