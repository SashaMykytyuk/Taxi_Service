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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        public BLLClient Client = new BLLClient(new Dal(new TaxiContext()));

        Client client;

        public Client AboutClient()
        {
            return new Client() { Email = client.Email ,Password = client.Password, FirstName = client.FirstName, SecondName = client.SecondName };
        }

        public ICollection<Order> AllOrders()
        {
            return Client.GetOrders(client.Id);
        }

        public string Authorization(string Email, string Password)
        {
            client = Client.Authorization(Email, Password);
            if (client == null)
                return "Wrong email or password";
            else return "";
        }

        public string ChangeInfoAboutClient(Changes changes, string param)
        {
            string str = Client.ChangeInfo(client.Id, changes, param);
            client = Client.Authorization(client.Email, client.Password);
            return str;
        }

        public string CreateOrder(Order order)
        {
            return Client.CreateOrder(client.Id, order);
        }

        public double GetPrice(double km, ClassesOfCar classes)
        {
            return Client.GetPrice(km, classes);
        }

        public string Registration(Client client)
        {
            return Client.CreateClient(client);
        }

        public string SendMessageToDispatcher(string Title, string Message)
        {
            if (Client.SendMessageToDispatcher(client, Title, Message) == true)
                return "Message is send";
            else return "Error in send message";
        }
    }
}
