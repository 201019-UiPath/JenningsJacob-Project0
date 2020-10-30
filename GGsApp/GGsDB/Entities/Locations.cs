using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Locations
    {
        public Locations()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
