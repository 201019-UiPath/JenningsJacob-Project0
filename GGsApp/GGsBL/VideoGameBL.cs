using GgsDB;

namespace GGsBL
{
    public class VideoGameBL
    {
        IRepository repo = new VideoGameRepo();

        public void AddVideoGame(VideoGame videoGame){
            repo.AddVideoGameAsync(videoGame);
        }
    }
}