using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface ICampaingSendRepository
    {

        tCampaignSend Get(int id);
        void Add(tCampaignSend entity);
        int Complete();
        IEnumerable<tCampaignSend> GetAllDetailsCampaingsSent();

    }
}
