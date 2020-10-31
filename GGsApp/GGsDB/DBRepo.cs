using GGsDB.Models;
using GGsDB.Entities;
using GGsDB.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace GGsDB
{
    /// <summary>
    /// Repository resposible for updating database
    /// </summary>
    public class DBRepo : IVideoGameRepo, IManagerRepo, ICustomerRepo
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
            return (Customer) context.Customers.Where(x => x.Email == email);
        }

    }
}