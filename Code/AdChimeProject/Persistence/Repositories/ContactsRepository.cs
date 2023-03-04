using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace AdChimeProject.Persistence.Repositories
{
    public class ContactsRepository : IContactsRepository
    {

        protected readonly AdChimeContext Context;
        public ContactsRepository(AdChimeContext context)
        {
            Context = context;
        }


        public Contacts Get(int id)
        {
            return Context.Set<Contacts>().Find(id);
        }

        public IEnumerable<Contacts> GetAll()
        {
            return Context.Set<Contacts>().ToList();
        }


        public void Add(Contacts entity)
        {
            Context.Set<Contacts>().Add(entity);
        }


        public void Remove(Contacts entity)
        {
            Context.Set<Contacts>().Remove(entity);
        }


        public IList<Contacts> GetContactsWithOptin()
        {
            return AdChimeContext.Contacts.Where(c => c.optinSMS == true).ToList();
        }

        public Contacts GetInfoContact(int id)
        {
            return AdChimeContext.Contacts.Where(c => c.idContact == id).FirstOrDefault();
        }

        public Contacts GetInfoContactEdit(int id)
        {
            return AdChimeContext.Contacts.Where(c => c.idContact == id).FirstOrDefault();
        }


        public AdChimeContext AdChimeContext
        {
            get { return Context as AdChimeContext;  }
        }

        public int Complete()
        {
            return AdChimeContext.SaveChanges();
        }

    }
}