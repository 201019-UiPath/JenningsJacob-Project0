using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using GGsDB.Models;

namespace GGsDB
{
    public class VideoGameRepo : IRepository
    {
        private string filename = "GGsDB/Products/VideoGames.txt";
        public async void AddProductAsync(Product product)
        {
            using (FileStream fs = File.Create(path: filename)){
                await JsonSerializer.SerializeAsync(fs, product);
                Console.WriteLine("Video game being written to file");
            }
        }
    }
}
