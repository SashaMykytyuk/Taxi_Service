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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IServiceDriver
    {
        [OperationContract]
        string Authorization(string Email, string Password);
        [OperationContract]
        Driver AboutDriver();
        [OperationContract]
        ICollection<Car> AllCars();
        [OperationContract]
        ICollection<Order> AllOrders();
        [OperationContract]
        ICollection<Report> AllReports();
        [OperationContract]
        string ChangeInfo(Changes changes, string param);
        [OperationContract]
        string WriteToDispatcher(string Title, string Message);
    }
}
