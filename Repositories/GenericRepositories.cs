using CoreAndFood.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Repositories
{
    public class GenericRepositories<T> where T : class, new()
    {
        Context c = new Context();
        public List<T> ListItem()
        {
            return c.Set<T>().ToList();
        }
        public T GetItem(int id)
        {
            return c.Set<T>().Find(id);
        }
        public void AddItem(T p)
        {
            c.Set<T>().Add(p);
            c.SaveChanges();
        }
        public void DeleteItem(T p)
        {
            c.Set<T>().Remove(p);
            c.SaveChanges();
        }
        public void UpdateItem(T p)
        {
            c.Set<T>().Update(p);
            c.SaveChanges();
        }
        public List<T> ListItem(string p)
        {
            return c.Set<T>().Include(p).ToList();
        }

    }
}
