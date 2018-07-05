using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL;
using BLL;
namespace WcfService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Authorization(string Email, string Password);
        [OperationContract]
        string Registration(Client client);
        [OperationContract]
        Client AboutClient();
        [OperationContract]
        string ChangeInfoAboutClient(Changes changes, string param);
        [OperationContract]
        string SendMessageToDispatcher(string Title, string Message);
        [OperationContract]
        ICollection<Order> AllOrders();
        [OperationContract]
        string CreateOrder(Order order);
        [OperationContract]
        double GetPrice(double km, ClassesOfCar classes);
        [OperationContract]
        void LogOut();
    }

  


}
