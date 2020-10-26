using System;
using GGsDB;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace GGsDB
{
    public class GameConsoleRepo : IRepository
    {
        private string filename = "GGsDB/Products/GameConsoles.txt";
        public async void AddProductAsync(Product product)
        {
            using (FileStream fs = File.Create(path: filename)){
                await JsonSerializer.SerializeAsync(fs, product);
                Console.WriteLine("Game console being written to file");
            }
        }
    }
}