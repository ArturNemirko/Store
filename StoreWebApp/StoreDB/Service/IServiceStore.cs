using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDB.Entities;

namespace StoreDB.Service
{
    interface IServiceStore
    {
        IEnumerable<Store> GetAllStores();

        ICollection<Product> GetProductsStore(int id);
    }
}
