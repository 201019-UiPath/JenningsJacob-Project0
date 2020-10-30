using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Inventories
    {
        public Inventories()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
