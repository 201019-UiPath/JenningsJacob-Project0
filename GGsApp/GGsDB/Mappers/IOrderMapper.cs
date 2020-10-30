using GGsDB.Models;
using GGsDB.Entities;
using System.Collections.Generic;

namespace GGsDB.Mappers
{
    public interface IOrderMapper
    {
        Order ParseOrder(Orders order);
        Orders ParseOrder(Order order);
        List<Order> ParseOrder(ICollection<Orders> orders);
        ICollection<Orders> ParseOrder(List<Order> orders);
        
    }
}