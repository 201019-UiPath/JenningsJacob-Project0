using System;
using GGsDB.Repos;
using GGsDB.Models;

namespace GGsLib
{
    public class UserService
    {
        private IUserRepo repo;
        public UserService(IUserRepo repo)
        {
            this.repo = repo;
        }
        public void AddUser(User user)
        {
            repo.AddUser(user);
        }
        public void DeleteUser(User user)
        {
            repo.DeleteUser(user);
        }
        public User GetUserByEmail(string email)
        {
            return repo.GetUserByEmail(email);
        }
        public User GetUserById(int id)
        {
            return repo.GetUserById(id);
        }
        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }
    }
}
