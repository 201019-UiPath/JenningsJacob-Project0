﻿using System;
using System.Collections.Generic;

namespace GGsDB.Entities
{
    public partial class Lineitems
    {
        public int Id { get; set; }
        public int Orderid { get; set; }
        public int Videogameid { get; set; }
        public int Quantity { get; set; }
        public decimal Price {get; set;}

        public virtual Orders Order { get; set; }
        public virtual Videogames Videogame { get; set; }
    }
}
