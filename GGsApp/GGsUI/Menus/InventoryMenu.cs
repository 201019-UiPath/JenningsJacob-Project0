using GGsDB;
using System;

namespace GGsUI.Menus
{
    public class InventoryMenu : IMenu
    {
        private string userInput;
        private IInventoryRepo repo;
        public InventoryMenu(IInventoryRepo repo)
        {
            this.repo = repo;
        }

        public void Start()
        {
        //    repo.GetAllProducts(1);
        }
    }
}