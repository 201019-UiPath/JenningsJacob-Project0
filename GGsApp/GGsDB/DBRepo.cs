using GGsDB.Models;
using GGsDB.Entities;
using GGsDB.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace GGsDB
{
    /// <summary>
    /// Repository resposible for updating database
    /// </summary>
    public class DBRepo : IVideoGameRepo, IManagerRepo, ICustomerRepo, IInventoryRepo
    {
        private readonly GGsContext context;
        private readonly IMapper mapper;
        public DBRepo(GGsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async void AddCustomerAsync(Customer customer)
        {
            try
            {
                context.Customers.Add(mapper.ParseCustomer(customer));
                await context.SaveChangesAsync();
            } catch (Exception e)
            {
                Console.WriteLine("Could not add customer");
                Console.WriteLine(e.Message);
            }
        }

        public void AddVideoGameAsync(VideoGame videoGame)
        {
            context.Products.AddAsync(mapper.ParseVideoGame(videoGame));
            context.SaveChangesAsync();
        }

        public Customer GetCustomerByEmail(string email)
        {
            Customer customer = new Customer();
            customer = mapper.ParseCustomer(context.Customers.SingleOrDefault(x => x.Email == email));
            customer.Location = GetLocationById(customer.LocationId);
            return customer;
        }

        public Location GetLocationById(int? id)
        {
            if (id == null)
                return new Location();
            return mapper.ParseLocation(context.Locations.Single(x => x.Id == id));
        }

        public List<Inventory> GetAllInventories()
        {
            List<Inventory> allInventories = new List<Inventory>();
            foreach (var i in context.Inventories.ToList())
            {
                allInventories.Add(mapper.ParseInventory(i));
            }
            return allInventories;
        }

        public List<Product> GetAllProducts(int id)
        {            
            List<Product> allProducts = new List<Product>();
            var results = context.Inventories
                .Where(x => x.Id == id)
                .Include("Products")
                .ToList();

            foreach (var r in results)
            {
                foreach (var p in r.Products)
                {
                    if (p.Prodtype == 1)
                        allProducts.Add(mapper.ParseVideoGame(p));
                    if (p.Prodtype == 2)
                        allProducts.Add(mapper.ParseGameConsole(p));
                }
            }
            return allProducts;
        }
    }
}