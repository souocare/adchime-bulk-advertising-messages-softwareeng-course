using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class CampaignsService
    {

        private readonly ICampaingsRepository _campaignsRepo;

        public CampaignsService(ICampaingsRepository campaignsRepo)
        {
            _campaignsRepo = campaignsRepo;
        }

        public Campaings GetCampaingById(int id)
        {
            Campaings campaing = _campaignsRepo.Get(id);
            if (campaing == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return campaing;
        }


        public Campaings AddCampaign(string TitleCampaing, string Description, string Sender, int? idtemplate, string Text, string updatedbyuser)
        {
            Campaings campaings = new Campaings
            {
                TitleCampaing = TitleCampaing,
                Description = Description,
                Sender = Sender,
                idtemplate = idtemplate,
                Text = Text,
                updatedbyuser = updatedbyuser
            };
            _campaignsRepo.Add(campaings);
            return campaings;
        }



        public Campaings EditCampaign(string TitleCampaing, string Description, string Sender, int? idtemplate, string Text, string updatedbyuser, int idcampaign)
        {
            var campaing = _campaignsRepo.Get(idcampaign);
            if (campaing != null)
            {
                campaing.TitleCampaing = TitleCampaing;
                campaing.Description = Description;
                campaing.Sender = Sender;
                campaing.Text = Text;
                campaing.idtemplate = idtemplate;
                campaing.updatedate = DateTime.Now;
                campaing.updatedbyuser = updatedbyuser;

            } else
            {
                throw new ArgumentException("There is no such campaing with that id");
            }
            return campaing;

        }



        public IEnumerable<Campaings> GetAllCampaings()
        {
            return _campaignsRepo.GetAllCampaings();
        }


        public int Complete(Campaings campaing)
        {
            if (campaing == _campaignsRepo.Get(campaing.idcampaign))
            {
                return _campaignsRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}