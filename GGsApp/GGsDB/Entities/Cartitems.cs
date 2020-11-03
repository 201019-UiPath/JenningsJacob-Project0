using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Cartitems
    {
        public int Id { get; set; }
        public int Cartid { get; set; }
        public int Videogameid { get; set; }
        public int Quantity { get; set; }

        public virtual Carts Cart { get; set; }
        public virtual Videogames Videogame { get; set; }
    }
}
