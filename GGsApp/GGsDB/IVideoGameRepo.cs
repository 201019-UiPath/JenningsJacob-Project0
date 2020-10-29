using GGsDB.Models;

namespace GGsDB
{
    public interface IVideoGameRepo
    {
        void AddVideoGameAsync(VideoGame videoGame);
    }
}