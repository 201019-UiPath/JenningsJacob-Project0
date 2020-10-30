// using GGsDB.Entities;
// using GGsDB.Models;

// namespace GGsDB
// {
//     public class DBMapper : IMapper
//     {
//         public Customer ParseCustomer(Customers customer)
//         {
//             return new Customer(){
//                 FirstName = customer.Firstname,
//                 LastName = customer.Lastname,
//                 Email = customer.Email,
//                 Id = customer.Id,
//                 Age = customer.Age,
//                 HomeAddress = ParseLocation(customer.Location)
//                 // Order = 
//             };
//         }

//         public Customers ParseCustomer(Customer customer)
//         {
//             return new Customers()
//             {
//                 Firstname = customer.FirstName,
//                 Lastname = customer.LastName,
//                 Email = customer.Email,
//                 Id = customer.Id,
//                 Age = customer.Age,
//                 Location = ParseLocation(customer.HomeAddress)
//                 // Order = 
//             };
//         }

//         public Location ParseLocation(Locations location)
//         {
//             return new Location()
//             {
//                 Street = location.Street,
//                 City = location.City,
//                 State = location.State,
//                 ZipCode = location.Zipcode,
//                 Id = location.Id
//             };
//         }

//         public Locations ParseLocation(Location location)
//         {
//             return new Locations()
//             {
//                 Street = location.Street,
//                 City = location.City,
//                 State = location.State,
//                 Zipcode = location.ZipCode,
//                 Id = location.Id
//             };
//         }
//     }
// }