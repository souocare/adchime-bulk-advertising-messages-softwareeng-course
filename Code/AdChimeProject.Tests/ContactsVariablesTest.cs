using AdChimeProject.Persistence.Services;
using System;
using Xunit;
using AdChimeProject.Tests.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdChimeProject.Tests
{
    public class ContactsVariablesTest
    {
        private readonly ITestOutputHelper _output;
        public ContactsVariablesTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void RemoveRangeTeste()
        {
            InMemoryContactsVariablesRepository inMemoryContactsVariablesRepository = new InMemoryContactsVariablesRepository();
            ContactsVariablesService contactsvariableservice = new ContactsVariablesService(inMemoryContactsVariablesRepository);
            panelContactsVariable panelContactsVariable_teste = new panelContactsVariable
            {
                idlig = 1,
                idContact = 1,
                idVar = 1,
                sValue = "Variavel1",
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsVariablesRepository.Add(panelContactsVariable_teste);

            panelContactsVariable panelContactsVariable_testedois = new panelContactsVariable
            {
                idlig = 1,
                idContact = 1,
                idVar = 2,
                sValue = "Variavel2",
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsVariablesRepository.Add(panelContactsVariable_testedois);
            IEnumerable<panelContactsVariable> enum_panelcontactsvar = inMemoryContactsVariablesRepository.GetAll();

            // Testing the GetContactById method
            var check_ifusercreated = contactsvariableservice.RemoveRange(enum_panelcontactsvar);
            Assert.Equal(0, inMemoryContactsVariablesRepository.GetAll().Count());
            _output.WriteLine("Finished RemoveRangeTeste...\n\n");
        }


        [Fact]
        public void GetAllVariablesOfCertainContact()
        {
            InMemoryContactsVariablesRepository inMemoryContactsVariablesRepository = new InMemoryContactsVariablesRepository();
            ContactsVariablesService contactsvariableservice = new ContactsVariablesService(inMemoryContactsVariablesRepository);
            panelContactsVariable panelContactsVariable_teste = new panelContactsVariable
            {
                idlig = 1,
                idContact = 1,
                idVar = 1,
                sValue = "Variavel1",
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsVariablesRepository.Add(panelContactsVariable_teste);

            panelContactsVariable panelContactsVariable_testedois = new panelContactsVariable
            {
                idlig = 1,
                idContact = 1,
                idVar = 2,
                sValue = "Variavel2",
                insertdate = DateTime.Now,
                updatedate = DateTime.Now,
                updatedbyuser = "teste"
            };
            inMemoryContactsVariablesRepository.Add(panelContactsVariable_testedois);

            // Testing the RemovebyId method
            var check_ifuserremoved = contactsvariableservice.GetAllVariablesOfCertainContact(1);
            Assert.Equal(2, check_ifuserremoved.Count());
            _output.WriteLine("Finished GetAllVariablesOfCertainContact...\n\n");

        }




    }
}
