using System;
using GGsUI.Menus;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Repos;
using Serilog;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("GGsUI\\Logs\\GGsApp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Starting application...");
            GGsContext context = new GGsContext();
            DBMapper mapper = new DBMapper();
            IMenu main = new WelcomeMenu(ref context, mapper, new DBRepo(context, mapper), new DBRepo(context, mapper));
            main.Start();
        }
    }
}
