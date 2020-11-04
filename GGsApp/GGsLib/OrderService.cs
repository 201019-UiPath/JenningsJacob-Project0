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
        /// <summary>
        /// Prepares and completes order while updating appropriate tables in the database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cartService"></param>
        /// <param name="cartItemService"></param>
        /// <param name="videoGameService"></param>
        /// <param name="lineItemService"></param>
        /// <param name="inventoryItemService"></param>
        public Order MakePurchase(User user, CartService cartService, CartItemService cartItemService, 
        VideoGameService videoGameService, LineItemService lineItemService, InventoryItemService inventoryItemService)
        {
            Cart cart = cartService.GetCartByUserId(user.id);
            List<CartItem> items = cartItemService.GetAllCartItems(cart.id);

            Order order = new Order();
            decimal totalCost = 0;

            order.userId = user.id;
            order.locationId = user.locationId;
            DateTime orderDate = order.orderDate = DateTime.Now;
            AddOrder(order);

            Order newOrder = GetOrderByDate(orderDate);

            foreach (var item in items)
            {
                VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                LineItem lineItem = new LineItem();
                lineItem.orderId = newOrder.id;
                lineItem.videoGameId = item.videoGameId;
                lineItem.cost = videoGame.cost;
                lineItem.quantity = item.quantity;

                totalCost += (videoGame.cost * item.quantity);

                lineItemService.AddLineItem(lineItem);
                cartItemService.DeleteCartItem(item);

                InventoryItem inventoryItem = inventoryItemService.GetInventoryItem(user.locationId, videoGame.id);
                inventoryItem.quantity -= item.quantity;
                inventoryItemService.UpdateInventoryItem(inventoryItem);
            }

            newOrder.totalCost = totalCost;
            UpdateOrder(newOrder);
            return newOrder;
        }
        public void GenerateReceipt(Order newOrder, LocationService locationService, LineItemService lineItemService, VideoGameService videoGameService)
        {
            Location location = locationService.GetLocationById(newOrder.locationId);
            Console.WriteLine($"Date: {newOrder.orderDate}\tTotal: ${newOrder.totalCost}\tLocation: {location.city}, {location.state}");

            Console.WriteLine("Line items:");
            List<LineItem> newItems = lineItemService.GetAllLineItemsById(newOrder.id);
            foreach(var item in newItems)
            {
                VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                Console.Write($"{item.quantity}x\t");
                videoGame.PrintInfo();
            }
        }
    }
}