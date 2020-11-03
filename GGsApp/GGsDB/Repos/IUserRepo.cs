using GGsDB.Models;

namespace GGsDB.Repos
{
    public interface IUserRepo
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void DeleteUser(User user);
    }
}