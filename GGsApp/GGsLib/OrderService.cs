using GGsDB.Repos;
using GGsDB.Models;
using System.Collections.Generic;
using System;

namespace GGsLib
{
    public class OrderService
    {
        IOrderRepo repo;
        public OrderService(IOrderRepo repo)
        {
            this.repo = repo;
        }
        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }
        public void DeleteOrder(Order order)
        {
            repo.DeleteOrder(order);
        }
        public List<Order> GetAllOrdersByLocationId(int id)
        {
            return repo.GetAllOrdersByLocationId(id);
        }
        public List<Order> GetAllOrdersByUserId(int id)
        {
            return repo.GetAllOrdersByUserId(id);
        }
        public Order GetOrderByDate(DateTime date)
        {
            return repo.GetOrderByDate(date);
        }
        public Order GetOrderById(int id)
        {
            return repo.GetOrderById(id);
        }
        public Order GetOrderByLocationId(int id)
        {
            return repo.GetOrderByLocationId(id);
        }
        public Order GetOrderByUserId(int id)
        {
            return repo.GetOrderByUserId(id);
        }
        public List<Order> GetAllOrdersDateAsc(int userId)
        {
            return repo.GetAllOrdersDateAsc(userId);
        }
        public List<Order> GetAllOrdersDateDesc(int userId)
        {
            return repo.GetAllOrdersDateDesc(userId);
        }
        public List<Order> GetAllOrdersPriceAsc(int userId)
        {
            return repo.GetAllOrdersPriceAsc(userId);
        }
        public List<Order> GetAllOrdersPriceDesc(int userId)
        {
            return repo.GetAllOrdersPriceDesc(userId);
        }
        public void UpdateOrder(Order order)
        {
            repo.UpdateOrder(order);
        }
    }
}