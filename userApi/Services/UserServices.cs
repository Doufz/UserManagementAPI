using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userApi.Interfaces;

namespace userApi.Services
{
    public class UserServices : IUserServices
    {
        IUserRepository _userRepository;

        public UserServices(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task AddUser(User user)
        {
            var emailAlreadyExists = await _userRepository.CheckDuplicatedEmail(user.Email);
            if (emailAlreadyExists)
            {
                throw new ArgumentException("Email Already Exists");
            }

            var phoneAlreadyExists = await _userRepository.CheckDuplicatedPhone(user.Phone);
            if (phoneAlreadyExists)
            {
                throw new ArgumentException("Phone Already Exists");
            }

            await _userRepository.Add(user);
        }

        public Task<List<User>> Getusers()
        {
            return _userRepository.GetAll();
        }

        public async Task<User> Update(string id, User user)
        {
            return await _userRepository.Update(id, user);
        }

        public Task<User> Getuser(string ID)
        {
            return _userRepository.GetById(ID);
        }

        public async Task DeleteUser(string ID)
        {
            await _userRepository.Delete(ID);
        }
    }
}
