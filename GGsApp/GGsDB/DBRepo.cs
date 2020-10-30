using GGsDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GGsDB
{
    /// <summary>
    /// Repository resposible for updating database
    /// </summary>
    public class DBRepo : IVideoGameRepo, IManagerRepo, ICustomerRepo
    {
        private GGsContext context;
        public DBRepo(GGsContext context)
        {
            this.context = context;
        }

        public void AddCustomerAsync(Customer customer)
        {
            context.Customers.AddAsync(customer);
            context.SaveChangesAsync();
        }

        public void AddVideoGameAsync(VideoGame videoGame)
        {
            context.VideoGames.AddAsync(videoGame);
            context.SaveChangesAsync();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return (Customer) context.Customers.Single(x => x.Email == email);
        }

    }
}