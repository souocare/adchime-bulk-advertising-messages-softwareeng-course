using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdChimeProject.Tests.Persistence.Repositories
{
    public class InMemoryContactsRepository : IContactsRepository
    {
        private List<Contacts> _db = new List<Contacts>();
        public Exception ExceptionToThrow { get; set; }

        public Contacts Get(int id)
        {
            return _db.Find(x => x.idContact == id);
        }

        public IEnumerable<Contacts> GetAll()
        {
            return _db.ToList();
        }



        public void Add(Contacts entity)
        {
            _db.Add(entity);
        }


        public void Remove(Contacts entity)
        {
            _db.Remove(entity);
        }



        public IList<Contacts> GetContactsWithOptin()
        {
            return _db.Where(c => c.optinSMS == true).ToList();
        }

        public Contacts GetInfoContact(int id)
        {
            return _db.Where(c => c.idContact == id).FirstOrDefault();
        }

        public Contacts GetInfoContactEdit(int id)
        {
            return _db.FirstOrDefault(c => c.idContact == id);
        }


        public int Complete()
        {
            return 1;
        }

    }
}