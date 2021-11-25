# UserManagementAPI
![Generic badge](https://img.shields.io/badge/language-C#-purple.svg)
![Generic badge](https://img.shields.io/badge/version-1.0.0-orange.svg)


## Description
This api is responsable for Create, Read, Update and Delete.


## TO DO:
using System;
using System.ComponentModel.DataAnnotations;

namespace userApi
{
    public class User
    {
        public Guid Id { get; private init; }

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
            Id = Guid.NewGuid();
        }

        public User(string id = null, string name, string email, string password, string phone)
        {
            if (string.IsNullOrEmpty(id))
            {
                Id = Guid.NewGuid();
            }

            else
            {
                var validId = Guid.TryParse(id, out var result);
                if (validId == false)
                    throw new Exception("Invalid Id");
                Id = result;
            }

            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }

    }
}
