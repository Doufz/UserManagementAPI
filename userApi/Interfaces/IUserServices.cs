using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userApi.Interfaces
{
    public interface IUserServices
    {
       Task AddUser(User user);

       Task<List<User>> Getusers();

       Task<User> Getuser(string Id);

       Task<User> Update(string id, User user);

       Task DeleteUser(string Id);

    }
}
