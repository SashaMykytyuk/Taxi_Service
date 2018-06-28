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


            BLLDispatcher bLLDispatcher = new BLLDispatcher(new Dal(new TaxiContext()));
            //Console.WriteLine(      bLLDispatcher.CreateDispatcher(new Dispatcher() { Email = "email@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345Q6qw_" }));
            //Console.WriteLine( bLLDispatcher.CreateDriver(new Driver() { Email = "email@gmail.com", FirstName = "Dispatcher", SecondName = "#1", Password = "12345F6qw_" }, new Car() { Marka = "marka", Age=5, Volume=4, ClassOfCar = ClassesOfCar.For4Person }));

           
           BLLDriver blldriver = new BLLDriver(new Dal(new TaxiContext()));
            Driver driver = new Driver() { Email = "email@gmai.com", FirstName = "Dr", Password = "1234AD_45", SecondName = "sadf" };
            // Car car = new Car() { ClassOfCar = ClassesOfCar.For4Person, Volume = 5, Age = 7, Marka = "marka#2" };
            // Car car2 = new Car() { ClassOfCar = ClassesOfCar.For8Person, Volume = 5, Age = 7, Marka = "marka#3" };

            //   Console.WriteLine(blldriver.CreateCar(car2));
            //  Console.WriteLine(blldriver.ChangeCar(driver, car2));

            Console.WriteLine( blldriver.SetLocation(driver, new Location() { Lat = 10, Lng = 50 }));
        }

             
    }
}
