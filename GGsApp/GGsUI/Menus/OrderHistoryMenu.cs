using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;

namespace GGsUI.Menus
{
    public class OrderHistoryMenu : IMenu
    {
        private string userInput;
        private User user;
        private GGsContext context;
        private DBMapper mapper;
        private List<Order> orders;
        private IOrderRepo orderRepo;
        private OrderService orderService;
        private ILocationRepo locationRepo;
        private LocationService locationService;
        private ILineItemRepo lineItemRepo;
        private LineItemService lineItemService;
        private IVideoGameRepo videoGameRepo;
        private VideoGameService videoGameService;
        public OrderHistoryMenu(ref User user, ref GGsContext context)
        {   
            this.user = user;
            this.context = context;
            this.mapper = new DBMapper();
            this.orders = new List<Order>();

            this.orderRepo = new DBRepo(context, mapper);
            this.locationRepo = new DBRepo(context, mapper);
            this.lineItemRepo = new DBRepo(context, mapper);
            this.videoGameRepo = new DBRepo(context, mapper);

            this.orderService = new OrderService(orderRepo);
            this.locationService = new LocationService(locationRepo);
            this.lineItemService = new LineItemService(lineItemRepo);
            this.videoGameService = new VideoGameService(videoGameRepo);
        }
        public void Start()
        {
            do {
                Console.WriteLine("1. Sort by date ascending");
                Console.WriteLine("2. Sort by date descending");
                Console.WriteLine("3. Sort by price ascending");
                Console.WriteLine("4. Sort by price descending");
                Console.WriteLine("0. Go back");

                userInput = Console.ReadLine();
                switch(userInput) {
                    case "1":
                        orders = orderService.GetAllOrdersDateAsc(user.id);
                        GetOrders(orders);
                        break;
                    case "2":
                        orders = orderService.GetAllOrdersDateDesc(user.id);
                        GetOrders(orders);
                        break;
                    case "3":
                        orders = orderService.GetAllOrdersPriceAsc(user.id);
                        GetOrders(orders);
                        break;
                    case "4":
                        orders = orderService.GetAllOrdersPriceDesc(user.id);
                        GetOrders(orders);
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while(!userInput.Equals("0"));
        }

        public void GetOrders(List<Order> orders)
        {
            Console.WriteLine("\nOrder History:");
            foreach (var order in orders)
            {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($"Date: {order.orderDate}\tTotal: {order.totalCost}\tLocation: {location.city}, {location.state}");

                Console.WriteLine("\nLine items:");
                List<LineItem> items = lineItemService.GetAllLineItemsById(order.id);
                foreach(var item in items)
                {
                    VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                    videoGame.PrintInfo();
                }
            }
            // Clear orders in case they wish to change how they view it
            orders.Clear();
        }
    }
}