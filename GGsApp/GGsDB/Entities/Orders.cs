using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public int? Customerid { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<Products> Products { get; set; }
    }
}
