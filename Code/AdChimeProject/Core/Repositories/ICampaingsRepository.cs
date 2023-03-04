using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface ICampaingsRepository
    {
        Campaings Get(int id);
        void Add(Campaings entity);
        int Complete();
        IEnumerable<Campaings> GetAllCampaings();

    }
}
