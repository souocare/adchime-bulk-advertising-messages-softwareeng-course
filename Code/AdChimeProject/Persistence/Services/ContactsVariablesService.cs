using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class ContactsVariablesService
    {

        private readonly IContactsVariablesRepository _contactsvariableRepo;

        public ContactsVariablesService(IContactsVariablesRepository contactsvariableRepo)
        {
            _contactsvariableRepo = contactsvariableRepo;
        }

        public bool RemoveRange(IEnumerable<panelContactsVariable> entities)
        {
            foreach (panelContactsVariable contactsVariable in entities)
            {
                _contactsvariableRepo.Remove(contactsVariable);
            }

            foreach (panelContactsVariable contactsVariable in entities)
            {
                if (_contactsvariableRepo.Get(Convert.ToInt32(contactsVariable.idContact)) != null)
                {
                    throw new ArgumentException("There is no such template with that id");
                }
            }
            return true;

        }



        public IEnumerable<panelContactsVariable> GetAllVariablesOfCertainContact(int idcontacto)
        {
            var search_contact = _contactsvariableRepo.GetAllVariablesOfCertainContact(idcontacto);
            return search_contact;
        }


        public List<string> GetValues_Variable(string variable)
        {
            var values = _contactsvariableRepo.GetValues_Variable(variable);
            if (values == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return values;
        }


        public int Complete(panelContactsVariable contact)
        {
            if (contact == _contactsvariableRepo.Get(contact.idlig))
            {
                return _contactsvariableRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}