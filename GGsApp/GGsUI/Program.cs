﻿using System;
using GGsUI.Menus;

namespace GGsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu startMenu = new MainMenu();
            startMenu.Start();
        }
    }
}