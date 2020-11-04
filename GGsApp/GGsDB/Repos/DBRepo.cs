using System;
using System.Collections.Generic;
using System.Linq;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Models;

namespace GGsDB.Repos
{
    public class DBRepo : IRepo
    {
        private GGsContext context1;
        private DBMapper mapper;
        public DBRepo(GGsContext context1, DBMapper mapper)
        {
            this.context1 = context1;
            this.mapper = mapper;
        }
        public void AddCart(Cart cart)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Carts.Add(mapper.ParseCart(cart));
                context.SaveChanges();
            }
            
            
        }

        public void AddCartItem(CartItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Cartitems.Add(mapper.ParseCartItem(item));
                context.SaveChanges();
            }
        }

        public void AddInventoryItem(InventoryItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Inventoryitems.Add(mapper.ParseInventoryItem(item));
                context.SaveChanges();
            }
        }

        public void AddLineItem(LineItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Lineitems.Add(mapper.ParseLineItem(item));
                context.SaveChanges();
            }
        }

        public void AddLocation(Location location)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Locations.Add(mapper.ParseLocation(location));
                context.SaveChanges();
            }
        }

        public void AddOrder(Order order)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Orders.Add(mapper.ParseOrder(order));
                context.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Users.Add(mapper.ParseUser(user));
                context.SaveChanges();
            }
        }

        public void AddVideoGame(VideoGame videoGame)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Videogames.Add(mapper.ParseVideoGame(videoGame));
                context.SaveChanges();
            }
        }

        public void DeleteCart(Cart cart)
        {
            
            using (GGsContext context = new GGsContext())
            {
                List<CartItem> allItems = GetAllCartItems(cart.id);
                foreach(var item in allItems)
                    context.Cartitems.Remove(mapper.ParseCartItem(item));
                context.Carts.Remove(mapper.ParseCart(cart));
                context.SaveChanges();
            }
        }

        public void DeleteCartItem(CartItem item)
        {
            using (GGsContext context = new GGsContext()) 
            {
                context.Cartitems.Remove(mapper.ParseCartItem(item));
                context.SaveChanges();
            }
            
        }

        public void DeleteInventoryItem(InventoryItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Inventoryitems.Remove(mapper.ParseInventoryItem(item));
                context.SaveChanges();
            }
        }

        public void DeleteLineItem(LineItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Lineitems.Remove(mapper.ParseLineItem(item));
                context.SaveChanges();
            }
        }

        public void DeleteLocation(Location location)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Locations.Remove(mapper.ParseLocation(location));
                context.SaveChanges();
            }
        }

        public void DeleteOrder(Order order)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Orders.Remove(mapper.ParseOrder(order));
                context.SaveChanges();
            }
        }

        public void DeleteUser(User user)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Users.Remove(mapper.ParseUser(user));
                context.SaveChanges();
            }
        }

        public void DeleteVideoGame(VideoGame videoGame)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Videogames.Remove(mapper.ParseVideoGame(videoGame));
                context.SaveChanges();
            }
        }

        public List<CartItem> GetAllCartItems(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseCartItem(context.Cartitems.Where(x => x.Cartid == id).ToList());
            }
        }

        public List<InventoryItem> GetAllInventoryItemById(int id)
        {   
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseInventoryItem(context.Inventoryitems.Where(x => x.Id == id).ToList());
            }
        }

        public List<InventoryItem> GetAllInventoryItemByLocationId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseInventoryItem(context.Inventoryitems
                .Where(x => x.Locationid == id)
                .OrderBy(x => x.Id).
                ToList());
            }
        }
        public List<LineItem> GetAllLineItemsByOrderId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseLineItem(context.Lineitems.Where(x => x.Orderid == id).ToList());
            }
        }

        public List<Location> GetAllLocations()
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseLocation(context.Locations.Select(x => x).ToList());
            }
        }

        public List<Order> GetAllOrdersByLocationId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Locationid == id).ToList());
            }
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Userid == id).ToList());
            }
        }

        public List<Order> GetAllOrdersDateAsc(int userId)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderBy(x => x.Orderdate).ToList());
            }
        }

        public List<Order> GetAllOrdersDateDesc(int userId)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderByDescending(x => x.Orderdate).ToList());
            }
        }

        public List<Order> GetAllOrdersPriceAsc(int userId)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderBy(x => x.Totalcost).ToList());
            }
        }

        public List<Order> GetAllOrdersPriceDesc(int userId)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderByDescending(x => x.Totalcost).ToList());
            }
        }

        public List<VideoGame> GetAllVideoGames()
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseVideoGame(context.Videogames.Select(x => x).ToList());
            }
        }

        public List<VideoGame> GetAllVideoGamesById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseVideoGame(context.Videogames.Where(x => x.Id == id).ToList());
            }
        }

        public Cart GetCartById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                Cart cart = new Cart();
                cart = mapper.ParseCart(context.Carts.Single(x => x.Id == id));
                cart.user = GetUserById(cart.userId);
                cart.cartItems = GetAllCartItems(cart.id);
                return cart;
            }
        }

        public Cart GetCartByUserId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                Cart cart = new Cart();
                cart = mapper.ParseCart(context.Carts.First(x => x.Userid == id));
                cart.cartItems = GetAllCartItems(cart.id);
                return cart;
            }
        }

        public CartItem GetCartItemById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseCartItem(context.Cartitems.Single(x => x.Id == id));
            }
        }

        public InventoryItem GetInventoryItem(int locId, int vgId)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Locationid == locId && x.Videogameid == vgId));
            }
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Id == id));
            }
        }

        public InventoryItem GetInventoryItemByLocationId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Locationid == id));
            }
        }

        public LineItem GetLineItemByOrderId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseLineItem(context.Lineitems.Single(x => x.Id == id));
            }
        }

        public Location GetLocationById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseLocation(context.Locations.Single(x => x.Id == id));
            }
        }

        public Order GetOrderByDate(DateTime orderDate)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Single(x => x.Orderdate == orderDate));
            }
        }

        public Order GetOrderById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Single(x => x.Id == id));
            }
        }

        public Order GetOrderByLocationId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Single(x => x.Locationid == id));
            }
        }

        public Order GetOrderByUserId(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseOrder(context.Orders.Single(x => x.Userid == id));
            }
        }

        public User GetUserByEmail(string email)
        {
            using (GGsContext context = new GGsContext())
            {
                User user = new User();
                user = mapper.ParseUser(context.Users.Single(x => x.Email == email));
                user.cart = GetCartByUserId(user.id);
                user.location = GetLocationById(user.locationId);
                // context.Entry<Carts>(mapper.ParseCart(user.cart)).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                return user;
            }
        }

        public User GetUserById(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                User user = new User();
                user = mapper.ParseUser(context.Users.Single(x => x.Id == id));
                user.cart = GetCartByUserId(user.id);
                user.location = GetLocationById(user.locationId);
                return user;
            }
        }

        public VideoGame GetVideoGame(int id)
        {
            using (GGsContext context = new GGsContext())
            {
                return mapper.ParseVideoGame(context.Videogames.Single(x => x.Id == id));
            }
        }

        public void UpdateCart(Cart cart)
        {
            using (GGsContext context1 = new GGsContext())
            {
                context1.Update<Carts>(mapper.ParseCart(cart));
                context1.SaveChanges();
            }
        }

        public void UpdateCartItem(CartItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Cartitems.Update(mapper.ParseCartItem(item));
                context.SaveChanges();
            }
        }

        public void UpdateInventoryItem(InventoryItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Inventoryitems.Update(mapper.ParseInventoryItem(item));
                context.SaveChanges();
            }
        }

        public void UpdateLineItem(LineItem item)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Lineitems.Update(mapper.ParseLineItem(item));
                context.SaveChanges();
            }
        }

        public void UpdateLocation(Location location)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Locations.Update(mapper.ParseLocation(location));
                context.SaveChanges();
            }
        }

        public void UpdateOrder(Order order)
        {
            using (GGsContext context = new GGsContext())
            {
                context.Orders.Update(mapper.ParseOrder(order));
                context.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (GGsContext context1 = new GGsContext())
            {
                context1.Update<Users>(mapper.ParseUser(user));
                context1.SaveChanges();
            }
            // context.Users.Update(mapper.ParseUser(user));
            
        }

        public void UpdateVideoGame(VideoGame videoGame)
        {
            using (GGsContext context1 = new GGsContext())
            {
                context1.Update<Videogames>(mapper.ParseVideoGame(videoGame));
                context1.SaveChanges();
            }
        }
    }
} 