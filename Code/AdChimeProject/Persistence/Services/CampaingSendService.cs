using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class CampaingSendService
    {

        private readonly ICampaingSendRepository _campaignssendRepo;

        public CampaingSendService(ICampaingSendRepository campaignssendRepo)
        {
            _campaignssendRepo = campaignssendRepo;
        }

        public tCampaignSend GetCampaingSentById(int id)
        {
            tCampaignSend campaing = _campaignssendRepo.Get(id);
            if (campaing == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return campaing;
        }


        public tCampaignSend AddSentCampaing(int? idcampaing, int? idrecipient, DateTime? sDatetoSend, string sSendbyWho)
        {
            tCampaignSend campaingsend = new tCampaignSend
            {
                idcampaing = idcampaing,
                idrecipient = idrecipient,
                sDatetoSend = sDatetoSend,
                sSendbyWho = sSendbyWho
            };
            _campaignssendRepo.Add(campaingsend);
            return campaingsend;
        }




        public IEnumerable<tCampaignSend> GetAllDetailsCampaingsSent()
        {
            return _campaignssendRepo.GetAllDetailsCampaingsSent();
        }


        public int Complete(tCampaignSend campaing)
        {
            if (campaing == _campaignssendRepo.Get(campaing.idEnvioEmail))
            {
                return _campaignssendRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}