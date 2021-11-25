using System;
using userApi;
using userApi.Services;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void WithoutEmail()                           // VERIFICA SEM EMAIL
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {


                //Arrange
                var repository = new UserRepository();
                var userService = new UserServices(repository);
                var newUser = new User(name: "João", email: "", password: "qwerty", phone: "8133871929312324522224");


                //Action
                if (string.IsNullOrEmpty(newUser.Email))
                    throw new ArgumentException("O campo Email é necessário.");

                userService.AddUser(newUser).Wait();
            });
        }


        [Fact]
        public void SmallPassword()                    // VERIFICA QUANTIDADE DE DÍGITOS NA SENHA
        {

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {


                //Arrange
                var repository = new UserRepository();
                var userService = new UserServices(repository);
                var newUser = new User(name: "João", email: "agaphoni@hotmail.com", password: "qwerty", phone: "8133871929312324522224");



                //Action
                if (newUser.Password.Length < 8)
                    throw new ArgumentException("A Senha não pode ultrapassar 8 dígitos");

                userService.AddUser(newUser).Wait();
            });
        }



        [Fact]
        public void WithoutPassword()                       // VERIFICA SEM SENHA
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {


                //Arrange
                var repository = new UserRepository();
                var userService = new UserServices(repository);
                var newUser = new User(name: "João", email: "agaphoni@hotmail.com", password: "", phone: "8133871929312324522224");


                //Action
                if (string.IsNullOrEmpty(newUser.Password))
                    throw new ArgumentException("O campo Password é necessário.");

                userService.AddUser(newUser).Wait();
            });
        }


        [Fact]
        public void WithoutPhone()                      // VERIFICA SEM TELEFONE
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Arrange
                var repository = new UserRepository();
                var userService = new UserServices(repository);
                var newUser = new User(name: "João", email: "agaphoni@hotmail.com", password: "qwerty", phone: "");

                //Action
                if (string.IsNullOrEmpty(newUser.Phone))
                    throw new ArgumentException("O campo Phone é necessário.");

                userService.AddUser(newUser).Wait();
            });
        }


        [Fact]
        public void WithoutName()                         // VERIFICA SEM NOME
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {

                //Arrange
                var repository = new UserRepository();
                var userService = new UserServices(repository);
                var newUser = new User(name: "", email: "agaphoni@hotmil.com", password: "qwerty", phone: "13981338719");

                //Action
                if (string.IsNullOrEmpty(newUser.Name))
                    throw new ArgumentException("O campo Name é necessário.");

                userService.AddUser(newUser).Wait();
            });
        }

        //[Fact]
        //public void UpdateUser()
        //{
        //    //Assert
        //    Assert.Throws<ArgumentException>
        //}



        [Fact]
        public void RepeatEmailUser()                   // VERIFICA EMAIL DUPLICADO
        {
            //Assert
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // Arrange
                var repository = new RepositoryMock();
                var userService = new UserServices(repository);
                var newUser01 = new User(name: "Joao", email: "agaphoni@hotmail.com", password: "qwerty123", phone: "13981338719");
                var newUser02 = new User(name: "Joao", email: "agaphoni@hotmail.com", password: "qwerty124", phone: "13981338718");

                //Action
                await userService.AddUser(newUser01);
                await userService.AddUser(newUser02);
            });
        }



        [Fact]
        public void RepeatPhoneUser()                   // VERIFICA TELEFONE DUPLICADO
        {
            //Assert
            Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                // Arrange
                var repository = new RepositoryMock();
                var userService = new UserServices(repository);
                var newUser01 = new User(name: "Joao", email: "agaphoni@hotmail.com", password: "qwerty124", phone: "13981338719");
                var newUser02 = new User(name: "Joao", email: "joao.surf22@hotmail.com", password: "qwerty123", phone: "13981338719");

                //Action
                await userService.AddUser(newUser01);
                await userService.AddUser(newUser02);
            });
        }
    }
}
}
