using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Net.Mail;
// Щось не те з update
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
            order.Done = false;
            List<Driver> drivers = _dal.Get<Driver>().Where(elem => elem.Location != null && order.ClassOfCar == elem.Car.ClassOfCar).ToList();
            if (drivers == null)
            {
                drivers = _dal.Get<Driver>().Where(elem => elem.Location != null).ToList();
            }
            order.Driver = drivers[0];
            order.Client = client;
            _dal.Create<Order>(order);
            return "";
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

                _dal.Update<Driver>(driver);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        public string SetLocation(Driver driver, Location location)
        {
            driver.Location = location;
            try
            {
                _dal.Update(driver);
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public string ChangeCar(Driver driver, Car car)
        {
            try
            {
                driver.Car = car;
                _dal.Update<Driver>(driver);
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
      
    }
    public class BLLDispatcher : Bll
    {
        public BLLDispatcher(IDAL dal) : base(dal) { }
        public string CreateDriver(Driver driver, Car car)
        {
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
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
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
        public bool OrderDone(Order order)
        {
            if(order.Done == true)
                //
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
                _dal.Update<Order>(order);
                return true;
            }
            catch { return false; }
        }

    }
}
