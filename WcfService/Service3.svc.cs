using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service3 : IServiceDispatcher
    {
        public BLLDispatcher DispatcherBll = new BLLDispatcher(new Dal(new TaxiContext()));

        Dispatcher dispatcher;

        public Dispatcher AboutDispatcher()
        {
            return new Dispatcher()
            {
                Email = dispatcher.Email,
                FirstName = dispatcher.FirstName,
                Password = dispatcher.Password,
                SecondName = dispatcher.SecondName
            };
        }

        public ICollection<Car> AllCars()
        {
            return DispatcherBll.GetAllCars();
        }

        public ICollection<Driver> AllDrivers()
        {
            return DispatcherBll.GetAllDrivers();
        }

        public string Authorization(string Email, string Password)
        {
            dispatcher = DispatcherBll.Authorization(Email, Password);
            if (dispatcher == null)
                return "Wrong email or password";
            else return "";
        }

        public string CreateCar(Car car)
        {
            return DispatcherBll.CreateCar(car);
        }

        public string CreateDriver(Driver driver, int idCar)
        {
            return DispatcherBll.CreateDriver(driver, idCar);
        }


        public string Registration(Dispatcher dispatcher)
        {
            return DispatcherBll.CreateDispatcher(dispatcher);
        }
    }

}
