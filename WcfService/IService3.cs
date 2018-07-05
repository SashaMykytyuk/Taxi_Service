using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    [ServiceContract]
    public interface IServiceDispatcher
    {
        [OperationContract]
        string Authorization(string Email, string Password);
        [OperationContract]
        Dispatcher AboutDispatcher();
        [OperationContract]
        string Registration(Dispatcher dispatcher);
        [OperationContract]
        string CreateDriver(Driver driver, int idCar);
        [OperationContract]
        string CreateCar(Car car);
        [OperationContract]
        ICollection<Car> AllCars();
        [OperationContract]
        ICollection<Driver> AllDrivers();
    }
}
