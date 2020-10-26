using System;
using GGsDB;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace GGsDB
{
    public class VideoGameRepo : IRepository
    {
        private string filename = "GGsDB/Products/VideoGames.txt";
        public async void AddVideoGameAsync(VideoGame videoGame)
        {
            using (FileStream fs = File.Create(path: filename)){
                await JsonSerializer.SerializeAsync(fs, videoGame);
                Console.WriteLine("Video game being written to file");
            }
        }
    }
}
