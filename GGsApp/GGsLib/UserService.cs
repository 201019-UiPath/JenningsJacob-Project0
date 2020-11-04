﻿using System;
using System.Collections.Generic;
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
            List<User> allUsers = repo.GetAllUsers();
            foreach(var u in allUsers)
            {
                if (u.email.Equals(user.email))
                    throw new Exception("This email already exists.");
            }
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
