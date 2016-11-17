using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.DAL
{
    public class UnitOfWork : IDisposable
    {
        private Context dbContext = new Context();
        private StoreRepository storeRepository;
        private ProductRepository productRepository;

        public StoreRepository Stores
        {
            get
            {
                if (storeRepository == null)
                    storeRepository = new StoreRepository(dbContext);
                return storeRepository;
            }
        }

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(dbContext);
                return productRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
