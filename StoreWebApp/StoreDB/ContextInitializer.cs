using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDB.Entities;

namespace StoreDB
{
    class ContextInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            WorkingHours workingHours = new WorkingHours() {Open = DateTime.Now, Close = DateTime.Now};
            context.WorkingHourses.Add(workingHours);
            for (int i = 0; i < 10; ++i)
            {
                Store store = new Store() {Name = String.Format("Store {0}", i+1), Address = String.Format("Store address {0}", i+1),
                    WorkingHours = workingHours, Products = new List<Product>()};
                for(int j=0; j<10;++j)
                {
                    Product product = new Product() {Name = String.Format("Product {0}{1}", i+1,j+1), Description = "Description Product"};
                    context.Products.Add(product);
                    store.Products.Add(product);
                    
                }
                context.Stores.Add(store);
            }
            context.SaveChanges();
        }
    }
}
