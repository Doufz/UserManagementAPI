using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userApi.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<User> GetById(string id);

        Task Add(User newUser);

        Task Delete(string id);

        Task<User> Update(string id, User updatedUser);

        Task<bool> CheckDuplicatedEmail(string email);

        Task<bool> CheckDuplicatedPhone(string phone);

    }
}
