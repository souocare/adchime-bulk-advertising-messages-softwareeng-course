using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdChimeProject.Tests.Persistence.Repositories
{
    public class InMemoryTemplateSMSRepository : ITemplateSMSRepository
    {
        private List<TemplateSMS> _db = new List<TemplateSMS>();
        public Exception ExceptionToThrow { get; set; }


        public TemplateSMS Get(int id)
        {
            return _db.FirstOrDefault(x => x.idtemplate == id);
        }

        public IEnumerable<TemplateSMS> GetAll()
        {
            return _db.ToList();
        }



        public void Add(TemplateSMS entity)
        {
            _db.Add(entity);
        }


        public IEnumerable<TemplateSMS> GetAprovedTemplates()
        {
            return _db.Where(c => c.isaproved == true).ToList();
        }

        public IEnumerable<TemplateSMS> GetTemplateInfo(int id)
        {
            return _db.Where(c => c.idtemplate == id).ToList();
        }



        public int Complete()
        {
            return 1;
        }

    }
}