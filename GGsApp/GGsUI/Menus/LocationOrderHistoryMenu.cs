using System;
using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;
using GGsDB.Repos;
using GGsLib;

namespace GGsUI.Menus
{
    public class LocationOrderHistoryMenu : IMenu
    {
        private string userInput;
        private int locId;
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
        
        public LocationOrderHistoryMenu(ref User user, ref GGsContext context)
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
                Console.WriteLine("\nSelect a location:");
                List<Location> locations = locationService.GetAllLocations();
                foreach (var l in locations)
                {
                    Console.WriteLine($"{l.id}. {l.city}, {l.state}");
                }
                Console.WriteLine("0. Go back");
                locId = Int32.Parse(Console.ReadLine());
                if (locId == 0)
                    break;
                Console.WriteLine("\nPlease select an option");
                Console.WriteLine("1. Sort by date ascending");
                Console.WriteLine("2. Sort by date descending");
                Console.WriteLine("3. Sort by price ascending");
                Console.WriteLine("4. Sort by price descending");
                Console.WriteLine("0. Go back");

                userInput = Console.ReadLine();
                switch(userInput) {
                    case "1":
                        orders = orderService.GetAllLocationOrdersDateAsc(locId);
                        GetOrders(orders);
                        break;
                    case "2":
                        orders = orderService.GetAllLocationOrdersDateDesc(locId);
                        GetOrders(orders);
                        break;
                    case "3":
                        orders = orderService.GetAllLocationOrdersPriceAsc(locId);
                        GetOrders(orders);
                        break;
                    case "4":
                        orders = orderService.GetAllLocationOrdersPriceDesc(locId);
                        GetOrders(orders);
                        break;
                    case "0":
                        break;
                    default:
                        break;
                }
            } while(!userInput.Equals("0"));
        }
        /// <summary>
        /// Prints out order information
        /// </summary>
        /// <param name="orders">List of orders you want to print</param>
        public void GetOrders(List<Order> orders)
        {
            Console.WriteLine("\nOrder History:\n");
            foreach (var order in orders)
            {
                Location location = locationService.GetLocationById(order.locationId);
                Console.WriteLine($"Date: {order.orderDate}\tTotal: ${order.totalCost}\tLocation: {location.city}, {location.state}");

                Console.WriteLine("Line items:");
                List<LineItem> newItems = lineItemService.GetAllLineItemsById(order.id);
                foreach(var item in newItems)
                {
                    VideoGame videoGame = videoGameService.GetVideoGame(item.videoGameId);
                    Console.Write($"{item.quantity}x\t");
                    videoGame.PrintInfo();
                }
                // orderService.GenerateReceipt(order, locationService, lineItemService, videoGameService);
                Console.WriteLine();
            }
            // Clear orders in case they wish to change how they view it
            orders.Clear();
        }
    }
} 