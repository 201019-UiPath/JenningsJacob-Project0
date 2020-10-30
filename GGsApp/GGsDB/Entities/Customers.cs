using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int? Locationid { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
