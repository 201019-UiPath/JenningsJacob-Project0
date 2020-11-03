using System;
using GGsUI.Menus;
using GGsDB.Entities;
using GGsDB.Mappers;
using GGsDB.Repos;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            GGsContext context = new GGsContext();
            DBMapper mapper = new DBMapper();
            IMenu main = new WelcomeMenu(ref context, mapper, new DBRepo(context, mapper), new DBRepo(context, mapper), new DBRepo(context, mapper));
            main.Start();
        }
    }
}
