using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using userApi;

namespace UserApiTest
{
    class ServicesMock
    {
        private RepositoryMock userRepository;
        public ServicesMock(RepositoryMock repository)
        {
            userRepository = repository;
        }
        public async Task AddUser(User user)
        {
           userRepository.Add(user);
        }

        public List<User> Getusers()
        {
            return userRepository.GetAll();
        }

        public User UpdateUser(string id, User user)
        {
            return userRepository.Update(id, user);
        }

        public User Getuser(string id)
        {
            return userRepository.GetById(id);
        }

        public void DeleteUser(string id)
        {
            userRepository.Delete(id);
        }
    }
}
