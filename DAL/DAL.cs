using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Як правильно розбить ці ф-ції у Dal i IDAL ?
namespace DAL
{
    public interface IDAL
    {
        void Create<T>(T _element) where T: class;
        void Delete<T>(T _element) where T: class;
        ICollection<T> Get<T>() where T : class;
        void Update<T>(T item) where T : class;
    }


    public class Dal : IDAL
    {
        DbContext context;
        public Dal(DbContext _context)
        {
            context = _context;
        }

        public void Create<T>(T _element) where T : class
        {
            context.Set<T>().Add(_element);
            context.SaveChanges();
        }

        public void Delete<T>(T _element) where T : class
        {
            context.Set<T>().Remove(_element);
            context.SaveChanges();
        }

        public ICollection<T> Get<T>() where T : class
        {
            return context.Set<T>().ToList();
        }

        public void Update<T>(T item) where T:class
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
