using GGsDB.Entities;
using GGsDB.Models;

namespace GGsDB.Mappers
{
    public interface IInventoryMapper
    {
        Inventory ParseInventory(Inventories inventory);
        Inventories ParseInventory(Inventory inventory);
    }
}