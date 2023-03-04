using AdChimeProject.Persistence.Services;
using System;
using Xunit;
using AdChimeProject.Tests.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdChimeProject.Tests
{
    public class ContactsTest
    {
        private readonly ITestOutputHelper _output;
        public ContactsTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetContactTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_teste = new Contacts
            {
                idContact = 1,
                Name = "Name_teste",
                LastName = "Lastname_teste",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_teste);

            // Testing the GetContactById method
            var check_ifusercreated = contactsservice.GetContactById(1);
            Assert.Equal(contacto_teste, check_ifusercreated);
            Assert.Equal(contacto_teste.Name, check_ifusercreated.Name);
            _output.WriteLine("Finished GetContactTeste...\n\n");
        }


        [Fact]
        public void RemoveContactTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_test = new Contacts
            {
                idContact = 2,
                Name = "Name_testedois",
                LastName = "Lastname_testedois",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_test);

            // Testing the RemovebyId method
            var check_ifuserremoved = contactsservice.RemovebyId(2);
            Assert.True(check_ifuserremoved);
            _output.WriteLine("Finished RemoveContactTeste...\n\n");

        }


        [Fact]
        public void GetAllContactsTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_teste = new Contacts
            {
                idContact = 1, Name = "Name_teste", LastName = "Lastname_teste",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_teste);

            Contacts contacto_testdois = new Contacts
            {
                idContact = 2, Name = "Name_testedois", LastName = "Lastname_testedois", bActive = true,
                PhoneNumber = "919191919", CountryCodePhone = "+351", Country = "Portugal", optinSMS = true, created_at = DateTime.Now, updatedate = DateTime.Now, updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_testdois);

            // Testing the RemovebyId method
            var check_allcontacts = contactsservice.GetAllContacts();
            Assert.Equal(2, check_allcontacts.Count());
            _output.WriteLine("Finished GetAllContactsTeste...\n\n");
        }



        [Fact]
        public void AddContactTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            contactsservice.AddContact("Name", "Lastname", true, "9191", "+351", "Pt", true, "goncalo.fonseca");
            var allcontacts = contactsservice.GetAllContacts();
            Assert.Equal("Name", allcontacts.ToList()[0].Name);
            _output.WriteLine("Finished AddContactTeste...\n\n");
        }


        [Fact]
        public void EditContactTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_teste = new Contacts
            {
                idContact = 1,
                Name = "Name_teste",
                LastName = "Lastname_teste",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_teste);

            // Testing the GetContactById method
            var check_ifuseredited = contactsservice.EditContact("Name_teste2", "Lastname_teste", true, "9191", "+351", "Portugal", true, "teste", DateTime.Now, 1);
            Assert.Equal("Name_teste2", check_ifuseredited.Name);
            _output.WriteLine("Finished EditContactTeste...\n\n");
        }


        [Fact]
        public void GetAllContactsWithOptinTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_teste = new Contacts
            {
                idContact = 1,
                Name = "Name_teste",
                LastName = "Lastname_teste",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_teste);

            Contacts contacto_testdois = new Contacts
            {
                idContact = 2,
                Name = "Name_testedois",
                LastName = "Lastname_testedois",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = false,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_testdois);

            // Testing the RemovebyId method
            var check_allcontacts = contactsservice.GetContactsWithOptin();
            Assert.Equal(1, check_allcontacts.Count());
            _output.WriteLine("Finished GetAllContactsWithOptinTeste...\n\n");
        }


        [Fact]
        public void GetInfoContactTeste()
        {
            InMemoryContactsRepository inMemoryContactsRepository = new InMemoryContactsRepository();
            ContactsService contactsservice = new ContactsService(inMemoryContactsRepository);
            Contacts contacto_teste = new Contacts
            {
                idContact = 1,
                Name = "Name_teste",
                LastName = "Lastname_teste",
                bActive = true,
                PhoneNumber = "919191919",
                CountryCodePhone = "+351",
                Country = "Portugal",
                optinSMS = true,
                created_at = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsRepository.Add(contacto_teste);

            // Testing the GetContactById method
            var check_contactinfo = contactsservice.GetInfoContact(1);
            Assert.Equal(contacto_teste.Name, check_contactinfo.Name);
            _output.WriteLine("Finished GetInfoContactTeste...\n\n");
        }

    }
}
