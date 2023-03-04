using AdChimeProject.Persistence.Services;
using System;
using Xunit;
using AdChimeProject.Tests.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdChimeProject.Tests
{
    public class AppUserTest
    {
        private readonly ITestOutputHelper _output;
        public AppUserTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetUsereste()
        {
            InMemoryAppUsersRepository inMemoryAppUsersRepository = new InMemoryAppUsersRepository();
            AppUserService appuserservice = new AppUserService(inMemoryAppUsersRepository);
            AppUsers user_teste = new AppUsers
            {
                idUser = 1,
                Name = "Name_teste",
                Email = "email@email.com",
                Password = "TestePassword", //A17CBD59676E032BBF28F47B60B8A38D8943D8B8C9BA0419E2408595956F409E
                iDLogin = Guid.NewGuid(),
                isadmin = true
            };
            inMemoryAppUsersRepository.Add(user_teste);

            // Testing the GetContactById method
            var check_ifusercreated = appuserservice.GetUserbyEmail("email@email.com");
            Assert.Equal(user_teste, check_ifusercreated);
            Assert.Equal(user_teste.Email, check_ifusercreated.Email);
            _output.WriteLine("Finished GetUsereste...\n\n");
        }



        [Fact]
        public void GetAllUsersTeste()
        {
            InMemoryAppUsersRepository inMemoryAppUsersRepository = new InMemoryAppUsersRepository();
            AppUserService appuserservice = new AppUserService(inMemoryAppUsersRepository);
            AppUsers user_teste = new AppUsers
            {
                idUser = 1,
                Name = "Name_teste",
                Email = "email@email.com",
                Password = "TestePassword", //A17CBD59676E032BBF28F47B60B8A38D8943D8B8C9BA0419E2408595956F409E
                iDLogin = Guid.NewGuid(),
                isadmin = true
            };
            inMemoryAppUsersRepository.Add(user_teste);

            AppUsers userdois_teste = new AppUsers
            {
                idUser = 2,
                Name = "Namedois_teste",
                Email = "emaildois@email.com",
                Password = "TestePassword", //A17CBD59676E032BBF28F47B60B8A38D8943D8B8C9BA0419E2408595956F409E
                iDLogin = Guid.NewGuid(),
                isadmin = false
            };
            inMemoryAppUsersRepository.Add(userdois_teste);

            // Testing the RemovebyId method
            var check_allusers = appuserservice.GetAllUsers();
            Assert.Equal(2, check_allusers.Count());
            _output.WriteLine("Finished GetAllUsersTeste...\n\n");
        }



        [Fact]
        public void AddUserTeste()
        {
            InMemoryAppUsersRepository inMemoryAppUsersRepository = new InMemoryAppUsersRepository();
            AppUserService appuserservice = new AppUserService(inMemoryAppUsersRepository);
            appuserservice.AddUser("Name", "emaildois@email.com", "TestePassword",true);
            var allcontacts = appuserservice.GetUserbyEmail("emaildois@email.com");
            Assert.Equal("emaildois@email.com", allcontacts.Email);
            //Testing the password encryption below
            Assert.Equal("A17CBD59676E032BBF28F47B60B8A38D8943D8B8C9BA0419E2408595956F409E", allcontacts.Password.ToString());
            _output.WriteLine("Finished AddUserTeste...\n\n");
        }


        [Fact]
        public void EditUserTeste()
        {
            InMemoryAppUsersRepository inMemoryAppUsersRepository = new InMemoryAppUsersRepository();
            AppUserService appuserservice = new AppUserService(inMemoryAppUsersRepository);
            AppUsers user_teste = new AppUsers
            {
                idUser = 1,
                Name = "Name_teste",
                Email = "email@email.com",
                Password = "TestePassword", //A17CBD59676E032BBF28F47B60B8A38D8943D8B8C9BA0419E2408595956F409E
                iDLogin = Guid.NewGuid(),
                isadmin = true
            };
            inMemoryAppUsersRepository.Add(user_teste);

            // Testing the GetContactById method
            var check_ifuseredited = appuserservice.EditUser("Name_teste2", "email@email.com", "TestePassword",true);
            Assert.Equal("Name_teste2", check_ifuseredited.Name);
            _output.WriteLine("Finished EditUserTeste...\n\n");
        }


    }
}
