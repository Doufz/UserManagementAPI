using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using userApi.Data;
using userApi.Interfaces;

namespace userApi
{
    public class UserRepository : ApiDbContext, IUserRepository
    {
        public readonly DbSet<User> DbCollection;

        public UserRepository()
        {
            DbCollection = Set<User>();
        }

        public Task<List<User>> GetAll()
        {
            var user = DbCollection.AsEnumerable().ToList();
            return Task.FromResult(user);
        }
        public async Task<User> GetById(string id)
        {
            return await DbCollection.FindAsync(id);
        }

        public async Task Add(User newUser)
        {
            DbCollection.Add(newUser);
            await SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var user = await GetById(id);
            DbCollection.Remove(user);
            await SaveChangesAsync();
        }
        public async Task<User> Update(string id, User updatedUser)
        {
            var user = await GetById(id);
            user.Name = updatedUser.Name;
            user.Phone = updatedUser.Phone;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;
            await SaveChangesAsync();
            return user;
        }

        public Task<bool> CheckDuplicatedEmail(string email)
        {
            var emailExists = DbCollection.AsEnumerable().Any(user => user.Email == email);
            return Task.FromResult(emailExists);
        }
  
        public Task<bool> CheckDuplicatedPhone(string phone)
        {
            var nameExists = DbCollection.AsEnumerable().Any(user => user.Phone == phone);
            return Task.FromResult(nameExists);
        }
    }
}
