using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Mail;
namespace BLL
{
    public abstract class Bll
    {
        protected IDAL _dal;
        public Bll(IDAL dal)
        {
            _dal = dal;
        }
        public bool SendMessage(AbstractPerson personFrom, AbstractPerson personWho, string Title, string Message)
        {
            Task.Run(() =>
            {

                MailMessage m = new MailMessage(new MailAddress(personFrom.Email, personFrom.SecondName), new MailAddress(personWho.Email));
                m.Subject = Title;
                m.Body = Message;

                          try
                          {
                              SmtpClient smtp = new SmtpClient("aspmx.l.google.com", 25);
                              //smtp.Credentials = new NetworkCredential();
                              smtp.EnableSsl = true;
                              smtp.Send(m);
                              return true;
                          }
                          catch
                          {
                              return false;
                          }

                      });
                   return true;

        }
    }

    
    public enum Changes { FirstName, SecondName, Password, Email};

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
        public ICollection<Order> GetOrders(Client client)
        {
            return _dal.Get<Order>().Where(elem => elem.Client == client).ToList();
        }
        public string CreateOrder(Client client, Order order)
        {
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
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }  //
        public string ChangeInfo(Client client, Changes change,  string param)
        {
            if (client == null)
                return "Authorization!!!";
            switch(change)
            {
                case Changes.Email:
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
    }

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
        public string CreateReport(Driver driver)
        {
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
        public string SetLocation(Driver driver, Location location)
        {
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
        public string ChangeCar(Driver driver, Car car)
        {
            try
            {
                driver.Car = car;
                _dal.ChangeDriver(driver.Id, driver);
                return "";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public ICollection<Order> GetOrders(Driver driver)
        {
            return _dal.Get<Order>().Where(elem => elem.Driver == driver).ToList();
        }
        public ICollection<Report> GetReports(Report report)
        {
            return _dal.Get<Report>().Where(elem => elem == report).ToList();
        }
        public string ChangeInfo(Driver driver, Changes change, string param)
        {
            if (driver == null)
                return "Authorization!!!";
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
