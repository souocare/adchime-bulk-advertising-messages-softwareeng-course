using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdChimeProject.Tests.Persistence.Repositories
{
    public class InMemoryContactsVariablesRepository : IContactsVariablesRepository
    {
        private List<panelContactsVariable> _db = new List<panelContactsVariable>();
        public Exception ExceptionToThrow { get; set; }

        public panelContactsVariable Get(int id)
        {
            return _db.Find(x => x.idContact == id);
        }

        public IEnumerable<panelContactsVariable> GetAll()
        {
            return _db.ToList();
        }

        public void Add(panelContactsVariable entity)
        {
            _db.Add(entity);
        }

        public void Remove(panelContactsVariable entity)
        {
            _db.Remove(entity);
        }



        public IEnumerable<panelContactsVariable> GetAllVariablesOfCertainContact(int id)
        {
            return _db.Where(c => c.idContact == id).ToList();
        }

        public List<string> GetValues_Variable(string variable)
        {
            return _db.Where(x => x.panelContact.optinSMS == true).Where(x => x.tVarContact.VarName == variable).Select(x => x.sValue).Distinct().ToList();
        }


        public int Complete()
        {
            return 1;
        }

    }
}