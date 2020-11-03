using Xunit;
using GGsDB;
using GGsDB.Models;
// using GGsDB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GGsDB.Mappers;

namespace GGsTest.GGsDBTest
{
    
    public class DBRepoTest
    {
        // private DBRepo repo;
        // private DBMapper mapper;
        // private readonly Customer testCustomer = new Customer()
        // {
        //     FirstName = "Jacob",
        //     LastName = "Jennings",
        //     Email = "jacob.jennings@revature.net",
        //     Age = 23
        // };

        // private void Seed(GGsContext testContext)
        // {
        //     testContext.Customers.AddRange(testCustomer);
        //     testContext.SaveChanges();
        // }

        // [Fact]
        // public void AddCustomerShouldAdd()
        // {
        //     // Arrange
        //     var options = new DbContextOptionsBuilder<GGsContext>().UseInMemoryDatabase("AddCustomersShouldAdd").Options;
        //     using var testContext = new GGsContext(options);
        //     repo = new DBRepo(testContext, mapper);

        //     // Act
        //     repo.AddCustomerAsync(testCustomer);

        //     // Assert
        //     using var assertContext = new GGsContext(options);
        //     Assert.NotNull(assertContext.Customers.Single(c => c.FirstName == testCustomer.FirstName));
        // }
        
        // [Fact]
        // public void GetCustomerByEmailShouldGetCustomer()
        // {
        //     // Arrange
        //     var options = new DbContextOptionsBuilder<GGsContext>().UseInMemoryDatabase("GetCustomerByEmailShouldGetCustomer").Options;
        //     using var testContext = new GGsContext(options);
        //     Seed(testContext);

        //     // Act
        //     using var assertContext = new GGsContext(options);
        //     repo = new DBRepo(testContext, mapper);
        //     var result = repo.GetCustomerByEmail("jacob.jennings@revature.net");

        //     // Assert
        //     Assert.NotNull(result);
        //     Assert.Equal("Jacob", result.FirstName);
        // }
    }
}