using GGsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GGsDB
{
    public interface IRepository
    {
        void AddProductAsync(Product product);
         
    }
}