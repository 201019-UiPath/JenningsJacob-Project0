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
        private GGsContext context;
        private DBMapper mapper;
        public DBRepo(GGsContext context, DBMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddCart(Cart cart)
        {
            context.Carts.Add(mapper.ParseCart(cart));
            context.SaveChanges();
        }

        public void AddCartItem(CartItem item)
        {
            context.Cartitems.Add(mapper.ParseCartItem(item));
            context.SaveChanges();
        }

        public void AddInventoryItem(InventoryItem item)
        {
            context.Inventoryitems.Add(mapper.ParseInventoryItem(item));
            context.SaveChanges();
        }

        public void AddLineItem(LineItem item)
        {
            context.Lineitems.Add(mapper.ParseLineItem(item));
            context.SaveChanges();
        }

        public void AddLocation(Location location)
        {
            context.Locations.Add(mapper.ParseLocation(location));
            context.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public void AddUser(User user)
        {
            context.Users.Add(mapper.ParseUser(user));
            context.SaveChanges();
        }

        public void AddVideoGame(VideoGame videoGame)
        {
            context.Videogames.Add(mapper.ParseVideoGame(videoGame));
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(mapper.ParseCart(cart));
            context.SaveChanges();
        }

        public void DeleteCartItem(CartItem item)
        {
            context.Cartitems.Remove(mapper.ParseCartItem(item));
            context.SaveChanges();
        }

        public void DeleteInventoryItem(InventoryItem item)
        {
            context.Inventoryitems.Remove(mapper.ParseInventoryItem(item));
            context.SaveChanges();
        }

        public void DeleteLineItem(LineItem item)
        {
            context.Lineitems.Remove(mapper.ParseLineItem(item));
            context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            context.Locations.Remove(mapper.ParseLocation(location));
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(mapper.ParseUser(user));
            context.SaveChanges();
        }

        public void DeleteVideoGame(VideoGame videoGame)
        {
            context.Videogames.Remove(mapper.ParseVideoGame(videoGame));
            context.SaveChanges();
        }

        public List<CartItem> GetAllCartItems(int id)
        {
            return mapper.ParseCartItem(context.Cartitems.Where(x => x.Cartid == id).ToList());
        }

        public List<InventoryItem> GetAllInventoryItemById(int id)
        {
            return mapper.ParseInventoryItem(context.Inventoryitems.Where(x => x.Id == id).ToList());
        }

        public List<InventoryItem> GetAllInventoryItemByLocationId(int id)
        {
            return mapper.ParseInventoryItem(context.Inventoryitems.Where(x => x.Locationid == id).ToList());
        }
        public List<LineItem> GetAllLineItemsByOrderId(int id)
        {
            return mapper.ParseLineItem(context.Lineitems.Where(x => x.Orderid == id).ToList());
        }

        public List<Location> GetAllLocations()
        {
            return mapper.ParseLocation(context.Locations.Select(x => x).ToList());
        }

        public List<Order> GetAllOrdersByLocationId(int id)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Locationid == id).ToList());
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Userid == id).ToList());
        }

        public List<Order> GetAllOrdersDateAsc(int userId)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderBy(x => x.Orderdate).ToList());
        }

        public List<Order> GetAllOrdersDateDesc(int userId)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderByDescending(x => x.Orderdate).ToList());
        }

        public List<Order> GetAllOrdersPriceAsc(int userId)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderBy(x => x.Totalcost).ToList());
        }

        public List<Order> GetAllOrdersPriceDesc(int userId)
        {
            return mapper.ParseOrder(context.Orders.Where(x => x.Userid == userId).OrderByDescending(x => x.Totalcost).ToList());
        }

        public List<VideoGame> GetAllVideoGames()
        {
            return mapper.ParseVideoGame(context.Videogames.Select(x => x).ToList());
        }

        public List<VideoGame> GetAllVideoGamesById(int id)
        {
            return mapper.ParseVideoGame(context.Videogames.Where(x => x.Id == id).ToList());
        }

        public Cart GetCartById(int id)
        {
            Cart cart = new Cart();
            cart = mapper.ParseCart(context.Carts.Single(x => x.Id == id));
            cart.user = GetUserById(cart.userId);
            cart.cartItems = GetAllCartItems(cart.id);
            return cart;
        }

        public Cart GetCartByUserId(int id)
        {
            Cart cart = new Cart();
            cart = mapper.ParseCart(context.Carts.Single(x => x.Userid == id));
            cart.cartItems = GetAllCartItems(cart.id);
            return cart;
        }

        public CartItem GetCartItemById(int id)
        {
            return mapper.ParseCartItem(context.Cartitems.Single(x => x.Id == id));
        }

        public InventoryItem GetInventoryItem(int locId, int vgId)
        {
            return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Locationid == locId && x.Videogameid == vgId));
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Id == id));
        }

        public InventoryItem GetInventoryItemByLocationId(int id)
        {
            return mapper.ParseInventoryItem(context.Inventoryitems.Single(x => x.Locationid == id));
        }

        public LineItem GetLineItemByOrderId(int id)
        {
            return mapper.ParseLineItem(context.Lineitems.Single(x => x.Id == id));
        }

        public Location GetLocationById(int id)
        {
            return mapper.ParseLocation(context.Locations.Single(x => x.Id == id));
        }

        public Order GetOrderByDate(DateTime orderDate)
        {
            return mapper.ParseOrder(context.Orders.Single(x => x.Orderdate == orderDate));
        }

        public Order GetOrderById(int id)
        {
            return mapper.ParseOrder(context.Orders.Single(x => x.Id == id));
        }

        public Order GetOrderByLocationId(int id)
        {
            return mapper.ParseOrder(context.Orders.Single(x => x.Locationid == id));
        }

        public Order GetOrderByUserId(int id)
        {
            return mapper.ParseOrder(context.Orders.Single(x => x.Userid == id));
        }

        public User GetUserByEmail(string email)
        {
            User user = new User();
            user = mapper.ParseUser(context.Users.Single(x => x.Email == email));
            user.cart = GetCartByUserId(user.id);
            user.location = GetLocationById(user.locationId);
            // context.Entry<Carts>(mapper.ParseCart(user.cart)).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return user;
        }

        public User GetUserById(int id)
        {
            User user = new User();
            user = mapper.ParseUser(context.Users.Single(x => x.Id == id));
            user.cart = GetCartByUserId(user.id);
            user.location = GetLocationById(user.locationId);
            return user;
        }

        public VideoGame GetVideoGame(int id)
        {
            return mapper.ParseVideoGame(context.Videogames.Single(x => x.Id == id));
        }

        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(mapper.ParseCart(cart));
            context.SaveChanges();
        }

        public void UpdateCartItem(CartItem item)
        {
            context.Cartitems.Update(mapper.ParseCartItem(item));
            context.SaveChanges();
        }

        public void UpdateInventoryItem(InventoryItem item)
        {
            context.Inventoryitems.Update(mapper.ParseInventoryItem(item));
            context.SaveChanges();
        }

        public void UpdateLineItem(LineItem item)
        {
            context.Lineitems.Update(mapper.ParseLineItem(item));
            context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            context.Locations.Update(mapper.ParseLocation(location));
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(mapper.ParseOrder(order));
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(mapper.ParseUser(user));
            context.SaveChanges();
        }

        public void UpdateVideoGame(VideoGame videoGame)
        {
            context.Videogames.Update(mapper.ParseVideoGame(videoGame));
            context.SaveChanges();
        }
    }
}