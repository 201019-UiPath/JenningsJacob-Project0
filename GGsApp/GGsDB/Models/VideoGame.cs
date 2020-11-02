namespace GGsDB.Models
{
    public class VideoGame : Product
    {
        public string Genre{get; set;}
        public string Platform{get; set;}
        // public string Rating{get; set;}
        public string ESRB{get; set;}
        public VideoGame()
        {
            Genre = "";
            Platform = "";
            ESRB = "";
        }
    }
}