using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class VarContactsRepository : IVarContactsRepository
    {
        protected readonly AdChimeContext Context;
        public VarContactsRepository(AdChimeContext context)
        {

            Context = context;
        }

        public tVarContact Get(int id)
        {
            return Context.Set<tVarContact>().Find(id);
        }
        public IEnumerable<tVarContact> GetAll()
        {
            return Context.Set<tVarContact>().ToList();
        }


        public void Add(tVarContact entity)
        {
            Context.Set<tVarContact>().Add(entity);
        }

        public List<string> GetAllVariableNames()
        {
            return AdChimeContext.tVarContacts.Select(x => x.VarName).ToList();
        }

        public string GetColType_Variable(string variable)
        {
            return AdChimeContext.tVarContacts.Where(x => x.VarName == variable).Select(x => x.colTypeFilter).FirstOrDefault();
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