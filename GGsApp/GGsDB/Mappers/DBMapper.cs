using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Models;

namespace GGsDB.Mappers
{
    public class DBMapper : IMapper
    {
        /// <summary>
        /// Converts Entity Customer to Model Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Customer ParseCustomer(Customers customer)
        {
            return new Customer()
            {
                Id = customer.Id,
                FirstName = customer.Firstname,
                LastName = customer.Lastname,
                Email = customer.Email,
                Age = customer.Age,
                LocationId = customer.Locationid,
                Location = ParseLocation(customer.Location),
                Orders = ParseOrder(customer.Orders)
            };
        }

        public Customers ParseCustomer(Customer customer)
        {
            return new Customers()
            {
                Id = customer.Id,
                Firstname = customer.FirstName,
                Lastname = customer.LastName,
                Email = customer.Email,
                Age = customer.Age,
                Locationid = customer.LocationId,
                Location = ParseLocation(customer.Location),
                Orders = ParseOrder(customer.Orders)
            };
        }

        public List<Customer> ParseCustomer(List<Customers> customers)
        {
            List<Customer> allCustomers = new List<Customer>();
            foreach(var customer in customers)
            {
                allCustomers.Add(ParseCustomer(customer));
            }
            return allCustomers;
        }

        public ICollection<Customers> ParseCustomer(ICollection<Customer> customers)
        {
            ICollection<Customers> allCustomers = new List<Customers>();
            foreach(var customer in customers)
            {
                allCustomers.Add(ParseCustomer(customer));
            }
            return allCustomers;
        }

        public GameConsole ParseGameConsole(Products product)
        {
            return new GameConsole(){
                Id = product.Id,
                Cost = product.Cost,
                Name = product.Name,
                Storage = product.Storage,
                IsDigitalEdition = product.Isdigitaledition
            };
        }

        public Products ParseGameConsole(GameConsole product)
        {
            return new Products(){
                Id = product.Id,
                Cost = product.Cost,
                Name = product.Name,
                Storage = product.Storage,
                Isdigitaledition = product.IsDigitalEdition
            };
        }

        public List<GameConsole> ParseGameConsole(ICollection<Products> products)
        {
            List<GameConsole> allGameConsoles = new List<GameConsole>();
            foreach(var gc in products)
            {
                allGameConsoles.Add(ParseGameConsole(gc));
            }
            return allGameConsoles;
        }

        public ICollection<Products> ParseGameConsole(List<GameConsole> products)
        {
            ICollection<Products> allGameConsoles = new List<Products>();
            foreach(var gc in products)
            {
                allGameConsoles.Add(ParseGameConsole(gc));
            }
            return allGameConsoles;
        }

        public Location ParseLocation(Locations location)
        {
            return new Location()
            {
                Street = location.Street,
                State = location.State,
                City = location.City,
                ZipCode = location.Zipcode
            };
        }

        public Locations ParseLocation(Location location)
        {
            return new Locations()
            {
                Street = location.Street,
                State = location.State,
                City = location.City,
                Zipcode = location.ZipCode
            };
        }

        public Order ParseOrder(Orders order)
        {
            return new Order()
            {
                Id = order.Id,
                CustomerId = order.Customerid,
                Customer = ParseCustomer(order.Customer),
                // Products = ParseProducts(order.Products)
            };
        }

        public Orders ParseOrder(Order order)
        {
            return new Orders()
            {
                Id = order.Id,
                Customerid = order.CustomerId,
                Customer = ParseCustomer(order.Customer)
                // Parse products
            };
        }

        public List<Order> ParseOrder(ICollection<Orders> orders)
        {
            List<Order> allOrders = new List<Order>();
            foreach(var order in orders)
            {
                allOrders.Add(ParseOrder(order));
            }
            return allOrders;
        }

        public ICollection<Orders> ParseOrder(List<Order> orders)
        {
            ICollection<Orders> allOrders = new List<Orders>();
            foreach(var order in orders)
            {
                allOrders.Add(ParseOrder(order));
            }
            return allOrders;
        }

        public VideoGame ParseVideoGame(Products product)
        {
            return new VideoGame(){
                Id = product.Id,
                Cost = product.Cost,
                Name = product.Name,
                Genre = product.Genre,
                Platform = product.Platform,
                ESRB = product.Esrb
            };
        }

        public Products ParseVideoGame(VideoGame product)
        {
            return new Products(){
                Id = product.Id,
                Cost = product.Cost,
                Name = product.Name,
                Genre = product.Genre,
                Platform = product.Platform,
                Esrb = product.ESRB,
                Prodtype = 1
            };
        }

        public List<VideoGame> ParseVideoGame(ICollection<Products> products)
        {
            List<VideoGame> allVideoGames= new List<VideoGame>();
            foreach (var vg in products)
            {
                allVideoGames.Add(ParseVideoGame(vg));
            }
            return allVideoGames;
        }

        public ICollection<Products> ParseVideoGame(List<VideoGame> products)
        {
            ICollection<Products> allVideoGames = new List<Products>();
            foreach (var vg in products)
            {
                allVideoGames.Add(ParseVideoGame(vg));
            }
            return allVideoGames;
        }
    }
}