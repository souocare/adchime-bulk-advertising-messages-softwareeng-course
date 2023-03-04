using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface IVarContactsRepository
    {
        tVarContact Get(int id);
        IEnumerable<tVarContact> GetAll();
        void Add(tVarContact entity);
        List<string> GetAllVariableNames();
        string GetColType_Variable(string variable);

        int Complete();
    }
}
