namespace GGsLib
{
    public class VideoGame : Product
    {
        public string Genre{get; set;}
        public string Platform{get; set;}
        // public string Rating{get; set;}
        public Rating ESRB{get; set;}
        public VideoGame()
        {
            Genre = "";
            Platform = "";
            ESRB = Rating.E;
        }
    }

    public enum Rating {
        E,
        E10,
        Teen,
        Mature
    }
}