using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDB.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public WorkingHours WorkingHours { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
