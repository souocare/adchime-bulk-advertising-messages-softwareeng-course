using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class RecipientsListsRepository : IRecipientsListsRepository
    {
        protected readonly AdChimeContext Context;
        public RecipientsListsRepository(AdChimeContext context)
        {
            Context = context;
        }

        public RecipientsLists Get(int id)
        {
            return Context.Set<RecipientsLists>().Find(id);
        }

        public IEnumerable<RecipientsLists> GetRecipientsLists()
        {
            return AdChimeContext.RecipientsLists.ToList();
        }

        public int Complete()
        {
            return AdChimeContext.SaveChanges();
        }

        public AdChimeContext AdChimeContext
        {
            get { return Context as AdChimeContext;  }
        }

    }
}