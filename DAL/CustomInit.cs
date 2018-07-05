using System.Data.Entity;

namespace DAL
{
    internal class CustomInit<T> : DropCreateDatabaseIfModelChanges<TaxiContext>
    {
        protected override void Seed(TaxiContext context)
        {
            context.Prices.Add(new Price() { ClassOfCar = ClassesOfCar.For4Person, Money = 5 });
            context.Prices.Add(new Price() { ClassOfCar = ClassesOfCar.For8Person, Money = 9 });
            context.Prices.Add(new Price() { ClassOfCar = ClassesOfCar.ForVantazh, Money = 7 });
            context.SaveChanges();
        }
    }
}