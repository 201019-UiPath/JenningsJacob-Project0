using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Products
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }
        public string Name { get; set; }
        public int? Prodtype { get; set; }
        public int? Inventoryid { get; set; }
        public int? Orderid { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public string Esrb { get; set; }
        public bool? Isdigitaledition { get; set; }
        public int? Storage { get; set; }

        public virtual Inventories Inventory { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Producttype ProdtypeNavigation { get; set; }
    }
}
