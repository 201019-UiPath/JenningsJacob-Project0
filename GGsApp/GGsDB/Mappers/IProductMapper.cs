using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Models;

namespace GGsDB.Mappers
{
    public interface IProductMapper
    {
        ICollection<Products> ParseProducts(List<Product> products);
        List<Product> ParseProducts(ICollection<Products> products);
    }
}