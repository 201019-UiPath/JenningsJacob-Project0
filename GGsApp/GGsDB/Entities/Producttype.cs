using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Producttype
    {
        public Producttype()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
        public string Prodtype { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
