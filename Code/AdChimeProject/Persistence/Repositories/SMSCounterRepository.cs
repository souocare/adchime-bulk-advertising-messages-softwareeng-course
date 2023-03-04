using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class SMSCounterRepository : ISMSCounterRepository
    {
        protected readonly AdChimeContext Context;
        public SMSCounterRepository(AdChimeContext context)
        {
            Context = context;

        }

        public int? GetSMSCounter()
        {
            return AdChimeContext.tSMSCounters.Where(c => c.idcounter == 1).First().Counter;
        }
        

        public AdChimeContext AdChimeContext
        {
            get { return Context as AdChimeContext;  }
        }

    }
}