using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface ITemplateSMSRepository
    {
        TemplateSMS Get(int id);
        IEnumerable<TemplateSMS> GetAll();

        void Add(TemplateSMS entity);
        IEnumerable<TemplateSMS> GetTemplateInfo(int id);
        IEnumerable<TemplateSMS> GetAprovedTemplates();
        int Complete();
    }
}
