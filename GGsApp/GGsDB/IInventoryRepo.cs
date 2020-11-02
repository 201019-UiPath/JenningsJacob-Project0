using System.Collections.Generic;
using GGsDB.Models;

namespace GGsDB
{
    public interface IInventoryRepo
    {
        List<Inventory> GetAllInventories();
        List<Product> GetAllProducts(int id);
    }
}