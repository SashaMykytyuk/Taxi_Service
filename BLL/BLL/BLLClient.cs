using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BLLClient : Bll
    {
        public BLLClient(IDAL dal) : base(dal) { }
        public string CreateClient(Client client)
        {
            try
            {
                client.FirstName = GenericParams.SetName(client.FirstName);
            }
            catch (ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                client.SecondName = GenericParams.SetName(client.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                client.Email = GenericParams.SetEmail(client.Email);
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
                client.Password = GenericParams.SetPassword(client.Password);
            }
            catch (ArgumentNullException)
            {
                return "Input password";
            }
            catch (FormatException)
            {
                return "Your password must contain as least 8 symvols, digits and big letters";
            }
            if (_dal.Get<Client>().Where(elem => elem.Email == client.Email).ToList().Count != 0)
                return "This email is in db";
            try
            {
                _dal.Create<Client>(client);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public Client Authorization(string email, string password)
        {
            return _dal.Get<Client>().FirstOrDefault(elem => elem.Email == email && elem.Password == password);
        }
        public ICollection<Order> GetOrders(int idClient)
        {
            return _dal.Get<Order>().Where(elem => elem.Client.Id == idClient).ToList();
        }
        public string CreateOrder(int idClient, Order order)
        {
            Client client = _dal.Get<Client>().FirstOrDefault(elem => elem.Id == idClient);
            if (client == null)
                return "Authorization!!!";
            if (order == null)
                return "Create order";
            if (order.LocationFrom == null || order.LocationTo == null)
                return "Select your route";
            if (order.Money <= 0)
                return "Wrong price";
            if (order.KM <= 0)
                return "Wrong distance";

            order.Done = false;
            order.Client = client;

            List<Driver> drivers = _dal.Get<Driver>().Where(elem => elem.Location != null && order.ClassOfCar == elem.Car.ClassOfCar).ToList();
            if (drivers == null || drivers.Count == 0)
            {
                drivers = _dal.Get<Driver>().Where(elem => elem.Location != null).ToList();
            }
            if (drivers != null && drivers.Count > 0)
            {
                order.Driver = drivers[0];
                drivers[0].Location = null;
                _dal.ChangeDriver(drivers[0].Id, drivers[0]);
            }
            else
                order.Driver = null;

            try
            {
                _dal.Create<Order>(order);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }  //
        public string ChangeInfo(int idClient, Changes change, string param)
        {
            Client client = _dal.Get<Client>().FirstOrDefault(elem => elem.Id == idClient);
            if (client == null)
                return "Authorization!!!";
            switch (change)
            {
                case Changes.Email:
                    if (_dal.Get<Client>().FirstOrDefault(elem => elem.Email == param) != null)
                        return "This email is in db";
                    try
                    {
                        client.Email = GenericParams.SetEmail(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input email";
                    }
                    break;
                case Changes.FirstName:
                    try
                    {
                        client.FirstName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input First name";
                    }
                    break;
                case Changes.SecondName:
                    try
                    {
                        client.SecondName = GenericParams.SetName(param);
                    }
                    catch (ArgumentNullException)
                    {
                        return "Input Second name";
                    }
                    break;
                case Changes.Password:
                    try
                    {
                        client.Password = GenericParams.SetPassword(param);
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
                _dal.ChangeClient(client.Id, client);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool SendMessageToDispatcher(Client client, string Title, string Message)
        {
            bool isSend;
            foreach(var elem in _dal.Get<Dispatcher>().ToList())
            {
                isSend =SendMessage(client, elem.Email, Title, Message);
                if (isSend == true)
                    return true;
            }
            return false;
        }
        public double GetPrice(double km, ClassesOfCar classes)
        {
            return _dal.Get<Price>().FirstOrDefault(elem => elem.ClassOfCar == classes).Money * km;
        }

    }
}
