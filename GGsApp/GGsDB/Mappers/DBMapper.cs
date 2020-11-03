using System.Collections.Generic;
using GGsDB.Entities;
using GGsDB.Models;

namespace GGsDB.Mappers
{
    public class DBMapper : IMapper
    {
        public Cart ParseCart(Carts cart)
        {
            return new Cart(){
                id = cart.Id,
                userId = cart.Userid,
            };
        }

        public Carts ParseCart(Cart cart)
        {
            return new Carts(){
                Id = cart.id,
                Userid = cart.userId,
            };
        }

        public List<Cart> ParseCart(ICollection<Carts> carts)
        {
            List<Cart> allCarts = new List<Cart>();
            foreach (var c in carts)
            {
                allCarts.Add(ParseCart(c));
            }
            return allCarts;
        }

        public ICollection<Carts> ParseCart(List<Cart> carts)
        {
            // if (carts.Equals(null))
            //     return new List<Carts>();
            ICollection<Carts> allCarts = new List<Carts>();
            foreach (var c in carts)
            {
                allCarts.Add(ParseCart(c));
            }
            return allCarts;
        }

        public CartItem ParseCartItem(Cartitems item)
        {
            // if (item.Equals(null))
            //     return new CartItem();
            return new CartItem(){
                id = item.Id,
                cartId = item.Cartid,
                videoGameId = item.Videogameid,
                quantity = item.Quantity,
                // cart = ParseCart(item.Cart),
                // videoGame = ParseVideoGame(item.Videogame)
            };
        }

        public Cartitems ParseCartItem(CartItem item)
        {
            // if (item.Equals(null))
            //     return new Cartitems();
            return new Cartitems(){
                Id = item.id,
                Cartid = item.cartId,
                Videogameid = item.videoGameId,
                Quantity = item.quantity,
                // Cart = ParseCart(item.cart),
                // Videogame = ParseVideoGame(item.videoGame)
            };
        }

        public List<CartItem> ParseCartItem(ICollection<Cartitems> item)
        {
            // if (item.Equals(null))
            //     return new List<CartItem>();
            List<CartItem> allItems = new List<CartItem>();
            foreach(var i in item)
            {
                allItems.Add(ParseCartItem(i));
            }
            return allItems;
        }

        public ICollection<Cartitems> ParseCartItem(List<CartItem> item)
        {
            // if (item.Equals(null))
            //     return new List<Cartitems>();
            ICollection<Cartitems> allItems = new List<Cartitems>();
            foreach(var i in item)
            {
                allItems.Add(ParseCartItem(i));
            }
            return allItems;
        }

        public InventoryItem ParseInventoryItem(Inventoryitems item)
        {
            // if (item.Equals(null))
            //     return new InventoryItem();
            return new InventoryItem()
            {
                id = item.Id,
                videoGameId = item.Videogameid,
                locationId = item.Locationid,
                quantity = item.Quantity,
                // videoGame = ParseVideoGame(item.Videogame),
                // location = ParseLocation(item.Location)
            };
        }

        public Inventoryitems ParseInventoryItem(InventoryItem item)
        {
            if (item.Equals(null))
                return new Inventoryitems();
            return new Inventoryitems()
            {
                Id = item.id,
                Videogameid = item.videoGameId,
                Locationid = item.locationId,
                Quantity = item.quantity,
                // Videogame = ParseVideoGame(item.videoGame),
                // Location = ParseLocation(item.location)
            };
        }

        public List<InventoryItem> ParseInventoryItem(ICollection<Inventoryitems> items)
        {
            // if (items.Equals(null))
            //     return new List<InventoryItem>();
            List<InventoryItem> allItems = new List<InventoryItem>();
            foreach (var item in items)
            {
                allItems.Add(ParseInventoryItem(item));
            }
            return allItems;
        }

        public ICollection<Inventoryitems> ParseInventoryItem(List<InventoryItem> items)
        {
            // if (items.Equals(null))
            //     return new List<Inventoryitems>();
            ICollection<Inventoryitems> allItems = new List<Inventoryitems>();
            foreach (var item in items)
            {
                allItems.Add(ParseInventoryItem(item));
            }
            return allItems;
        }

        public LineItem ParseLineItem(Lineitems item)
        {
            // if (item.Equals(null))
            //     return new LineItem();
            return new LineItem()
            {
                id = item.Id,
                orderId = item.Orderid,
                videoGameId = item.Videogameid,
                quantity = item.Quantity,
                // order = ParseOrder(item.Order),
                // videoGame = ParseVideoGame(item.Videogame),
                price = item.Price
            };
        }

        public Lineitems ParseLineItem(LineItem item)
        {
            if (item.Equals(null))
                return new Lineitems();
            return new Lineitems()
            {
                Id = item.id,
                Orderid = item.orderId,
                Videogameid = item.videoGameId,
                Quantity = item.quantity,
                // Order = ParseOrder(item.order),
                // Videogame = ParseVideoGame(item.videoGame),
                Price = item.price
            };
        }

        public List<LineItem> ParseLineItem(ICollection<Lineitems> items)
        {
            if (items.Equals(null))
                return new List<LineItem>();
            List<LineItem> allItems = new List<LineItem>();
            foreach (var item in items)
            {
                allItems.Add(ParseLineItem(item));
            }
            return allItems;
        }

        public ICollection<Lineitems> ParseLineItem(List<LineItem> items)
        {
            if (items.Equals(null))
                return new List<Lineitems>();
            ICollection<Lineitems> allItems = new List<Lineitems>();
            foreach (var item in items)
            {
                allItems.Add(ParseLineItem(item));
            }
            return allItems;
        }

        public Location ParseLocation(Locations location)
        {
            // if (location == null)
            //     return new Location();
            return new Location()
            {
                id = location.Id,
                street = location.Street,
                city = location.City,
                state = location.State,
                zipCode = location.Zipcode,
                // inventory = ParseInventoryItem(location.Inventoryitems)
            };
        }

        public Locations ParseLocation(Location location)
        {
            // if (location.Equals(null))
            //     return new Locations();
            return new Locations()
            {
                Id = location.id,
                Street = location.street,
                City = location.city,
                State = location.state,
                Zipcode = location.zipCode,
                // Inventoryitems = ParseInventoryItem(location.inventory)
            };
        }

        public List<Location> ParseLocation(ICollection<Locations> locations)
        {
            // if (locations.Equals(null))
            //     return new List<Location>();
            List<Location> allLocations = new List<Location>();
            foreach(var l in locations)
            {
                allLocations.Add(ParseLocation(l));
            }
            return allLocations;
        }

        public ICollection<Locations> ParseLocation(List<Location> locations)
        {
            // if (locations.Equals(null))
            //     return new List<Locations>();
            ICollection<Locations> allLocations = new List<Locations>();
            foreach(var l in locations)
            {
                allLocations.Add(ParseLocation(l));
            }
            return allLocations;
        }

        public Order ParseOrder(Orders order)
        {
            // if (order.Equals(null))
            //     return new Order();
            return new Order()
            {
                id = order.Id,
                userId = order.Userid,
                locationId = order.Locationid,
                orderDate = order.Orderdate,
                totalCost = order.Totalcost,
                // user = ParseUser(order.User),
                // location = ParseLocation(order.Location),
                // lineItems = ParseLineItem(order.Lineitems)
            };
        }

        public Orders ParseOrder(Order order)
        {
            // if (order.Equals(null))
            //     return new Orders();
            return new Orders()
            {
                Id = order.id,
                Userid = order.userId,
                Locationid = order.locationId,
                Orderdate = order.orderDate,
                Totalcost = order.totalCost,
                // User = ParseUser(order.user),
                // Location = ParseLocation(order.location),
                // Lineitems = ParseLineItem(order.lineItems)
            };
        }

        public List<Order> ParseOrder(ICollection<Orders> orders)
        {
            List<Order> allOrders = new List<Order>();
            foreach (var o in orders)
            {
                allOrders.Add(ParseOrder(o));
            }
            return allOrders;
        }

        public ICollection<Orders> ParseOrder(List<Order> orders)
        {
            ICollection<Orders> allOrders = new List<Orders>();
            foreach (var o in orders)
            {
                allOrders.Add(ParseOrder(o));
            }
            return allOrders;
        }

        public User ParseUser(Users user)
        {
            if (user.Type.Equals("Customer"))
                return new User()
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    locationId = user.Locationid,
                    type = User.userType.Customer
                };
            else
                return new User()
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    locationId = user.Locationid,
                    type = User.userType.Manager
                };
        }

        public Users ParseUser(User user)
        {
            // if (user.Equals(null))
            //     return new Users();
            return new Users()
                {
                    Id = user.id,
                    Name = user.name,
                    Email = user.email,
                    Locationid = user.locationId,
                    Type = user.type.ToString(),
                    // Carts = ParseCart(user.cart),
                    // Location = ParseLocation(user.location),
                    // Orders = ParseOrder(user.orders)
                };
        }

        public List<User> ParseUser(ICollection<Users> users)
        {
            List<User> allUsers = new List<User>();
            foreach (var u in users)
            {
                allUsers.Add(ParseUser(u));
            }
            return allUsers;
        }

        public ICollection<Users> ParseUser(List<User> users)
        {
            ICollection<Users> allUsers = new List<Users>();
            foreach (var u in users)
            {
                allUsers.Add(ParseUser(u));
            }
            return allUsers;
        }

        public VideoGame ParseVideoGame(Videogames videogame)
        {
            return new VideoGame()
            {
                id = videogame.Id,
                name = videogame.Name,
                cost = videogame.Cost,
                platform = videogame.Platform,
                esrb = videogame.Esrb
            };
        }

        public Videogames ParseVideoGame(VideoGame videogame)
        {
            return new Videogames()
            {
                Id = videogame.id,
                Name = videogame.name,
                Cost = videogame.cost,
                Platform = videogame.platform,
                Esrb = videogame.esrb
            };
        }

        public List<VideoGame> ParseVideoGame(ICollection<Videogames> videogames)
        {
            List<VideoGame> allVideoGames = new List<VideoGame>();
            foreach (var vg in videogames)
            {
                allVideoGames.Add(ParseVideoGame(vg));
            }
            return allVideoGames;
        }

        public ICollection<Videogames> ParseVideoGame(List<VideoGame> videogames)
        {
            ICollection<Videogames> allVideoGames = new List<Videogames>();
            foreach (var vg in videogames)
            {
                allVideoGames.Add(ParseVideoGame(vg));
            }
            return allVideoGames;
        }
    }
}