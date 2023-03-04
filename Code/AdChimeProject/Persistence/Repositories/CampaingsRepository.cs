using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class CampaingsRepository : ICampaingsRepository
    {
        protected readonly AdChimeContext Context;
        public CampaingsRepository(AdChimeContext context)
        {
            Context = context;
        }

        public Campaings Get(int id)
        {
            return Context.Set<Campaings>().Find(id);
        }

        public void Add(Campaings entity)
        {
            Context.Set<Campaings>().Add(entity);
        }

        public IEnumerable<Campaings> GetAllCampaings()
        {
            return AdChimeContext.Campaings.OrderByDescending(x => x.updatedate).ToList();
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