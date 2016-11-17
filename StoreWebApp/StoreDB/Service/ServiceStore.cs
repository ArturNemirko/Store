using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDB.Entities;

namespace StoreDB.Service
{
    public class ServiceStore : IServiceStore
    {
        Context dbContext = new Context();
        public IEnumerable<Store> GetAllStores()
        {
            return dbContext.Stores;
        }

        public ICollection<Product> GetProductsStore(int id)
        {
            return dbContext.Stores.Find(id).Products;
        }
    }
}
