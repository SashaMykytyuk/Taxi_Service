using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    // треба придумать як це все порозкидати по класах та інтерфейсах
    public interface IBLL
    {
        
    }



    public class BLL : IBLL
    {
        IDAL _dal;
        public BLL(IDAL dal)
        {
            _dal = dal;
        }
        public string CreateClient(Client client)
        {
            try
            {
                client.FirstName = CreatorPerson.SetName(client.FirstName);
            }
            catch(ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                client.SecondName = CreatorPerson.SetName(client.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                client.Email = CreatorPerson.SetEmail(client.Email);
            }
            catch(ArgumentNullException)
            {
                return "Input email"; 
            }
            catch(FormatException)
            {
                return "Wrong format email";
            }
            try
            {
                client.Password = CreatorPerson.SetPassword(client.Password);
            }
            catch(ArgumentNullException)
            {
                return "Input password";
            }
            catch(FormatException)
            {
                return "Your password must contain as least 8 symvols, digits and big letters";
            }
            try
            {
                _dal.Create<Client>(client);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public string CreateDriver(Driver driver, Car car)
        {
            try
            {
                driver.FirstName = CreatorPerson.SetName(driver.FirstName);
            }
            catch (ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                driver.SecondName = CreatorPerson.SetName(driver.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                driver.Email = CreatorPerson.SetEmail(driver.Email);
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
                driver.Password = CreatorPerson.SetPassword(driver.Password);
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
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public string CreateDispatcher(Dispatcher dispatcher)
        {
            try
            {
                dispatcher.FirstName = CreatorPerson.SetName(dispatcher.FirstName);
            }
            catch (ArgumentNullException)
            {
                return "Input First name";
            }
            try
            {
                dispatcher.SecondName = CreatorPerson.SetName(dispatcher.SecondName);
            }
            catch (ArgumentNullException)
            {
                return "Input Second name";
            }
            try
            {
                dispatcher.Email = CreatorPerson.SetEmail(dispatcher.Email);
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
                dispatcher.Password = CreatorPerson.SetPassword(dispatcher.Password);
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
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public string CreateCar(Car car)
        {
            try
            {
                car.Marka = CreatorPerson.SetName(car.Marka);
            }
            catch(ArgumentNullException)
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
            catch(Exception ex)
            {
                return ex.Message;
            }
            return "";
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
            catch(Exception ex)
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
        public ICollection<Client> GetAllDispatchers()
        {
            return _dal.Get<Dispatcher>();
        }
        public string SetLocation(Driver driver, Location location)
        {
            driver.Location = location;
            try
            {
                _dal.Update(driver);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        public ICollection<Order> GetOrders(Driver driver)
        {
            return _dal.Get<Order>().Where(elem => elem.Driver == driver).ToList();
        }
        public ICollection<Order> GetOrders(Client client)
        {
            return _dal.Get<Order>().Where(elem => elem.Client == client).ToList();
        }

    }
}
