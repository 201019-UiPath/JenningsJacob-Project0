using GGsDB.Entities;
using GGsDB.Models;

namespace GGsDB.Mappers
{
    public interface ILocationMapper
    {
        Location ParseLocation(Locations location); 
        Locations ParseLocation(Location location);
    }
}