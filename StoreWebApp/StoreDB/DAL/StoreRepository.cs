using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDB.Entities;

namespace StoreDB.DAL
{
    public class StoreRepository : IRepository<Store>
    {
        private Context dbContext;

        public StoreRepository(Context context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Store> GetAll()
        {
            return dbContext.Stores;
        }

        public Store GetElement(int id)
        {
            return dbContext.Stores.Find(id);
        }

        public void Create(Store item)
        {
            dbContext.Stores.Add(item);
        }

        public void Update(Store item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Store store = dbContext.Stores.Find(id);
            if (store != null)
                dbContext.Stores.Remove(store);
        }
    }
}
