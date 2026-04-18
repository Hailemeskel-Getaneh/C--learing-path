using System.Collections.Generic;
using System.Linq;
using GenericInventoryApp.Interfaces;

namespace GenericInventoryApp.Services
{
    public class Repository<T> where T : IEntity
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> GetAll()
        {
            return items;
        }

        public T GetById(int id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
                items.Remove(item);
        }
    }
}