using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class ContactsService
    {

        private readonly IContactsRepository _contactsRepo;

        public ContactsService(IContactsRepository contactsRepo)
        {
            _contactsRepo = contactsRepo;
        }


        public bool RemovebyId(int id)
        {
            Contacts search_contact = _contactsRepo.Get(id);
            if (search_contact == null)
            {
                throw new ArgumentException("The user does not exist!");
            }
            _contactsRepo.Remove(search_contact);

            Contacts check_contact_deleted = _contactsRepo.Get(id);
            if (check_contact_deleted != null)
            {
                throw new ArgumentException("It was not removed!");
            }
            return true;
        }


        public Contacts GetContactById(int id)
        {
            Contacts template = _contactsRepo.Get(id);
            if (template == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return template;
        }

        public IEnumerable<Contacts> GetAllContacts()
        {
            return _contactsRepo.GetAll();
        }

        public Contacts AddContact(string Name, string LastName, bool? bActive, string PhoneNumber, string CountryCodePhone, string Country, bool? optinSMS, string updatebyuser)
        {
            Contacts contact = new Contacts
            {
                Name = Name,
                LastName = LastName,
                bActive = bActive,
                PhoneNumber = PhoneNumber,
                CountryCodePhone = CountryCodePhone,
                Country = Country,
                optinSMS = optinSMS,
                updatedbyuser = updatebyuser
            };
            _contactsRepo.Add(contact);
            return contact;
        }


        public Contacts EditContact(string Name, string LastName, bool? bActive, string PhoneNumber, string CountryCodePhone, string Country, bool? optinSMS, string updatebyuser, DateTime? updatedate, int idcontact)
        {
            Contacts contact_toedit = _contactsRepo.Get(idcontact);
            if (contact_toedit != null)
            {
                contact_toedit.Name = Name;
                contact_toedit.LastName = LastName;
                contact_toedit.bActive = bActive;
                contact_toedit.PhoneNumber = PhoneNumber;
                contact_toedit.CountryCodePhone = CountryCodePhone;
                contact_toedit.Country = Country;
                contact_toedit.optinSMS = optinSMS;
                contact_toedit.updatedbyuser = updatebyuser;
                contact_toedit.updatedate = updatedate;

                _contactsRepo.Complete();
                
            }
            else
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return contact_toedit;
        }

        public IList<Contacts> GetContactsWithOptin()
        {
            return _contactsRepo.GetContactsWithOptin();
        }

        public Contacts GetInfoContact(int idcontact)
        {
            var contact = _contactsRepo.GetInfoContact(idcontact);
            if (contact == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return contact;
        }

        public Contacts GetInfoContactEdit(int idcontact)
        {
            var contact = _contactsRepo.GetInfoContactEdit(idcontact);
            if (contact == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return contact;
        }

        public int Complete(Contacts contact)
        {
            if (contact == _contactsRepo.Get(contact.idContact))
            {
                return _contactsRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}