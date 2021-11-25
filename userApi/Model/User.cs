using System;
using System.ComponentModel.DataAnnotations;

namespace userApi
{
    public class User
    {
        public string Id { get; private init; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public User()
        {
            Id = Guid.NewGuid().ToString();
        }

        public User(string name, string email, string password, string phone)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;

        }

    }
}
