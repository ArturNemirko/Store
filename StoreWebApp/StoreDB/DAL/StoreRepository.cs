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
            {
                if (store.Products != null && store.Products.Count > 0)
                    while (store.Products.Count > 0)
                    {
                        store.Products.Remove(store.Products.First());
                    }
                dbContext.Stores.Remove(store);
            }
        }

        public void AddProduct(int id, Product product)
        {
            GetElement(id).Products.Add(product);
        }
    }
}
