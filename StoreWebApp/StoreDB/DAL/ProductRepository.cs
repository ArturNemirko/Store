using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreDB.Entities;

namespace StoreDB.DAL
{
    public class ProductRepository : IRepository<Product>
    {
        private Context dbContext;

        public ProductRepository(Context context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products;
        }

        public Product GetElement(int id)
        {
            return dbContext.Products.Find(id);
        }

        public void Create(Product item)
        {
            dbContext.Products.Add(item);
        }

        public void Update(Product item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = dbContext.Products.Find(id);
            if (product != null)
                dbContext.Products.Remove(product);
        }
    }
}
