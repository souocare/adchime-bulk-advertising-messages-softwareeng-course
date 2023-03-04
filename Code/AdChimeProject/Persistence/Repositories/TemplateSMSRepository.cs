using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class TemplateSMSRepository : ITemplateSMSRepository
    {

        protected readonly AdChimeContext Context;
        public TemplateSMSRepository(AdChimeContext context)
        {

            Context = context;
        }
        public TemplateSMS Get(int id)
        {
            return Context.Set<TemplateSMS>().Find(id);
        }

        public IEnumerable<TemplateSMS> GetAll()
        {
            return Context.Set<TemplateSMS>().ToList();
        }

        public void Add(TemplateSMS entity)
        {
            Context.Set<TemplateSMS>().Add(entity);
        }


        public IEnumerable<TemplateSMS> GetAprovedTemplates()
        {
            return AdChimeContext.TemplateSMS.Where(c => c.isaproved == true).ToList();
        }


        public IEnumerable<TemplateSMS> GetTemplateInfo(int id)
        {
            return AdChimeContext.TemplateSMS.Where(c => c.idtemplate == id);
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