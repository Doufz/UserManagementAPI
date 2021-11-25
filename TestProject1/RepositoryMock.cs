using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using userApi.Data;
using userApi.Interfaces;

namespace userApi
{
    public class RepositoryMock
    {
        public readonly List<User> Users = new List<User>();

        public void Add(User user)
        {
            Users.Add(user);
        }
        public List<User> GetAll()
        {
            var allUsers = Users.ToList();
            return allUsers;
        }
        public User GetById(string id)
        {
            var user = Users.Find(user => user.Id == id);
            return user;
        }

        public User Update(string id, User updatedUser)
        {
            var user = GetById(id);
            user.Email = updatedUser.Email;
            user.Name = updatedUser.Name;
            user.Phone = updatedUser.Phone;
            user.Phone = updatedUser.Password;
            return user;
        }
        public void Delete(string id)
        {
            var user = GetById(id);
            Users.Remove(user);
        }
    }
}
