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
        public  readonly List<User> Users = new List<User>();

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

        public User Update(string id, User newUserInfo)
        {
            var newuser = GetById(id);
            newuser.Email = newUserInfo.Email;
            newuser.Name = newUserInfo.Name;
            newuser.Phone = newUserInfo.Phone;
            newuser.Phone = newUserInfo.Password;
            return newuser;
        }
        public void Delete(string id)
        {
            var user = GetById(id);
            Users.Remove(user);
        }
    }
}
