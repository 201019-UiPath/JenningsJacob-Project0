using GGsDB;
using GGsDB.Models;

namespace GGsUI.Menus
{
    public class ManagerLoginMenu : IMenu
    {
        private string userInput;
        private IManagerRepo repo;

        public ManagerLoginMenu(IManagerRepo repo)
        {
            this.repo = repo;
        }
        
        public void Start()
        {
            throw new System.NotImplementedException();
        }
    }
}