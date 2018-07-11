using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BLLClient bll = new BLLClient(new Dal(new TaxiContext()));
            //bll.CreateClient(new Client() { Email = "miss.elizaveta.rengan@gmail.com", FirstName = "Liza", SecondName = "Renzhyna", Password = "123456AS_" });



            //Console.WriteLine(      bLLDispatcher.CreateDispatcher(new Dispatcher() { Email = "email@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345Q6qw_" }));
            //Console.WriteLine( bLLDispatcher.CreateDriver(new Driver() { Email = "email@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345F6qw_" }, new Car() { Marka = "marka", Age=5, Volume=4, ClassOfCar = ClassesOfCar.For4Person }));


            // Driver driver = blldriver.Authorization("email@gmail.com", "12345F6qw_");
            //Console.WriteLine(blldriver.SetLocation(driver, new Location() { Lat=10, Lng=4 }));
            //foreach(var elem in blldriver.GetAllCars())
            //{
            //    Console.WriteLine(elem.Marka);
            //}
            // Car car = new Car() { ClassOfCar = ClassesOfCar.For4Person, Volume = 5, Age = 7, Marka = "marka#2" };
            // Car car2 = new Car() { ClassOfCar = ClassesOfCar.For8Person, Volume = 5, Age = 7, Marka = "marka#3" };

            //   Console.WriteLine(blldriver.CreateCar(car2));
            //  Console.WriteLine(blldriver.ChangeCar(driver, car2));

            //Console.WriteLine( blldriver.SetLocation(driver, new Location() { Lat = 10, Lng = 50 }));
           // BLLDispatcher bLLDispatcher = new BLLDispatcher(new Dal(new TaxiContext()));
           // Console.WriteLine(bLLDispatcher.CreateDriver(new Driver() { Email = "emailss@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345F6qw_" }, new Car() { Marka = "marka", Age = 5, Volume = 4, ClassOfCar = ClassesOfCar.For4Person }));
           // BLLDriver blldriver = new BLLDriver(new Dal(new TaxiContext()));
           //Driver driver =   blldriver.Authorization("emailss@gmail.com", "12345F6qw_");
           // blldriver.SetLocation(driver, new Location() { Lat = 2, Lng = 2 });
           // BLLClient bLLClient = new BLLClient(new Dal(new TaxiContext()));
           //      Console.WriteLine("Create: " + bLLClient.CreateClient(new Client() { Email = "miss.elizaveta.rengan@gmail.com", FirstName = "liZa", SecondName = "rEnZHyna", Password = "Q1234758sS_" }));

           //      Client client = bLLClient.Authorization("miss.elizaveta.rengan@gmail.com", "Q1234758sS_");

           //        Console.WriteLine("Create order: " +   bLLClient.CreateOrder(client, new Order() { ClassOfCar = ClassesOfCar.For4Person, Comment = "1", LocationFrom = new Location() { Lat = 5, Lng = 2 }, LocationTo = new Location() { Lat = 10, Lng = 4 } }));

            //     Console.WriteLine(bLLClient.ChangeInfo(client, Changes.Password, "Zizaveta12_"));
            //      foreach (var elem in bLLClient.GetOrders(client))
            //        Console.WriteLine(elem.Driver.Id + ";" + elem.Id);





            //BLLDispatcher bLLDispatcher = new BLLDispatcher(new Dal(new TaxiContext()));
            //Console.WriteLine( bLLDispatcher.CreateDriver(new Driver() { Email = "email@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345F6qw_" }, new Car() { Marka = "marka", Age=5, Volume=4, ClassOfCar = ClassesOfCar.For4Person }));

            //Order order = bLLDispatcher.GetOrders().ToList()[0];
            //Driver driver = bLLDispatcher.GetAllDrivers().ToList()[0];
            //Console.WriteLine(bLLDispatcher.ChangeDriverForOrder(order, driver));
        }

             
    }
}
