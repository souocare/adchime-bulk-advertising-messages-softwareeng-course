using AdChimeProject.Core;
using AdChimeProject.Persistence;
using AdChimeProject.Persistence.Repositories;
using AdChimeProject.Persistence.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace AdChimeProject.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly CampaignsService _campaignsService;
        private readonly CampaingSendService _campaignsendService;

        public CampaignsController(CampaignsService campaignsService,  CampaingSendService campaignsendService)
        {
            _campaignsService = campaignsService;
            _campaignsendService = campaignsendService;
        }

        public CampaignsController()
        {
            _campaignsService = new CampaignsService(new CampaingsRepository(new AdChimeContext()));
            _campaignsendService = new CampaingSendService(new CampaingSendRepository(new AdChimeContext()));
        }

        public ActionResult Campaigns()
        {
            ViewBag.Current = "Campaigns";
            return View(_campaignsService.GetAllCampaings());
        }

        public ActionResult NewCampaign()
        {

            ViewBag.Current = "Campaigns";
            return View();
        }

        [HttpPost]
        public ActionResult NewCampaign(Campaings model)
        {
            Campaings created_campaign = _campaignsService.AddCampaign(model.TitleCampaing, model.Description, model.Sender,
                model.idtemplate, model.Text ,Session["Nome"].ToString());

            _campaignsService.Complete(created_campaign);


            ViewBag.Current = "Campaigns";
            return RedirectToAction("Campaigns");
        }

        


        public ActionResult SendCampaign(int id)
        {
            ViewBag.Current = "Campaigns";
            Campaings tcamp = _campaignsService.GetCampaingById(id);
            ViewBag.toolEmail = tcamp;
            return View();
        }

        [HttpPost]
        public ActionResult SendCampaign(tCampaignSend modelsend)
        {
            tCampaignSend campaingsend = _campaignsendService.AddSentCampaing(modelsend.idcampaing, modelsend.idrecipient, modelsend.sDatetoSend, Session["Nome"].ToString());
            
            _campaignsendService.Complete(campaingsend);

            return RedirectToAction("Campaigns");
        }


        public ActionResult EditCampaign(int id)
        {
            ViewBag.Current = "Campaigns";
            return View(_campaignsService.GetCampaingById(id));
        }

        [HttpPost]
        public ActionResult EditCampaign(Campaings model)
        {

            var edited_campaing = _campaignsService.EditCampaign(model.TitleCampaing,
                model.Description, model.Sender, model.idtemplate, model.Text, Session["Nome"].ToString(), model.idcampaign);
            _campaignsService.Complete(edited_campaing);

            ViewBag.Current = "Campaigns";
            return RedirectToAction("Campaigns");
        }






    }
}