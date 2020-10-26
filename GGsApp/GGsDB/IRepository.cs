using GGsDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GGsDB
{
    public interface IRepository
    {
         Task<List<VideoGame>> GetAllVideoGamesAsync();
         
    }
}