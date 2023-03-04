using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class ContactsVariablesRepository : IContactsVariablesRepository
    {

        protected readonly AdChimeContext Context;
        public ContactsVariablesRepository(AdChimeContext context)
        {
            Context = context;

        }

        public panelContactsVariable Get(int id)
        {
            return Context.Set<panelContactsVariable>().Find(id);
        }
        public void Add(panelContactsVariable entity)
        {
            Context.Set<panelContactsVariable>().Add(entity);
        }
        public void Remove(panelContactsVariable entities)
        {
            Context.Set<panelContactsVariable>().Remove(entities);
        }

        public IEnumerable<panelContactsVariable> GetAllVariablesOfCertainContact(int id)
        {
            return AdChimeContext.panelContactsVariables.Where(c => c.idContact == id).ToList();
        }

        public List<string> GetValues_Variable(string variable)
        {
            // var listadadospaneluser = dbadchime.panelContactsVariables.Where(x => x.panelContact.optinSMS == 1).Where(x => x.tVarContact.VarName == elementvalue).Select(x => x.sValue).Distinct().ToList();
            return AdChimeContext.panelContactsVariables.Where(x => x.panelContact.optinSMS == true).Where(x => x.tVarContact.VarName == variable).Select(x => x.sValue).Distinct().ToList();
        }


        public AdChimeContext AdChimeContext
        {
            get { return Context as AdChimeContext; }
        }
        public int Complete()
        {
            return AdChimeContext.SaveChanges();
        }

    }
}