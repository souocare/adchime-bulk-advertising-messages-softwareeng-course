using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface IRecipientsListsRepository
    {
        RecipientsLists Get(int id);
        IEnumerable<RecipientsLists> GetRecipientsLists();
        int Complete();

    }
}
