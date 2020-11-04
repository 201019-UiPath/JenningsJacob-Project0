using Xunit;
using GGsDB;
using GGsDB.Models;
using GGsDB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GGsDB.Mappers;
using GGsDB.Repos;
using System.Collections.Generic;

namespace GGsTest.GGsDBTest
{
    
    public class DBRepoTest
    {
        private DBRepo repo;
        private DBMapper mapper;
        private readonly User testCustomer = new User()
        {
            name = "Jacob",
            email = "jacob.jennings@revature.net",
            locationId = 2,
            type = User.userType.Customer,
            cart = new Cart(),
            location = new Location(),
            id = 99,
            orders = new List<Order>()
        };

        private void Seed(GGsContext testContext)
        {
            testContext.Users.AddRange(mapper.ParseUser(testCustomer));
            testContext.SaveChanges();
        }

        [Fact]
        public void AddCustomerShouldAdd()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<GGsContext>().UseInMemoryDatabase("AddCustomersShouldAdd").Options;
            using var testContext = new GGsContext(options);
            repo = new DBRepo(testContext, mapper);

            // Act
            repo.AddUser(testCustomer);

            // Assert
            using var assertContext = new GGsContext(options);
            Assert.NotNull(assertContext.Users.Single(c => c.Name == testCustomer.name));
        }
        
        [Fact]
        public void GetCustomerByEmailShouldGetCustomer()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<GGsContext>().UseInMemoryDatabase("GetCustomerByEmailShouldGetCustomer").Options;
            using var testContext = new GGsContext(options);
            Seed(testContext);

            // Act
            using var assertContext = new GGsContext(options);
            repo = new DBRepo(testContext, mapper);
            var result = repo.GetUserByEmail("jacob.jennings@revature.net");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Jacob", result.name);
        }
    }
}