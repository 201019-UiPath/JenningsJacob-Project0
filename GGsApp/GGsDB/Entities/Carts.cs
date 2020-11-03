using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Carts
    {
        public Carts()
        {
            Cartitems = new HashSet<Cartitems>();
        }

        public int Id { get; set; }
        public int Userid { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Cartitems> Cartitems { get; set; }
    }
}
