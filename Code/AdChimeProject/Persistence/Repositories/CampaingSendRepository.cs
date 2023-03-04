using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class CampaingSendRepository : ICampaingSendRepository
    {
        protected readonly AdChimeContext Context;
        public CampaingSendRepository(AdChimeContext context)
        {
            Context = context;
        }

        public tCampaignSend Get(int id)
        {
            return Context.Set<tCampaignSend>().Find(id);
        }

        public void Add(tCampaignSend entity)
        {
            Context.Set<tCampaignSend>().Add(entity);
        }

        public IEnumerable<tCampaignSend> GetAllDetailsCampaingsSent()
        {
            return AdChimeContext.tCampaignSends.ToList();
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