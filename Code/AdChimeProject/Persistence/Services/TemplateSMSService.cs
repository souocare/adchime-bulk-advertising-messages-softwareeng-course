using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class TemplateSMSService
    {

        private readonly ITemplateSMSRepository _templatesmsRepo;

        public TemplateSMSService(ITemplateSMSRepository templatesmsRepo)
        {
            _templatesmsRepo = templatesmsRepo;
        }

        public TemplateSMS GetTemplateById(int id)
        {
            TemplateSMS template = _templatesmsRepo.Get(id);
            if (template == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return template;
        }

        public IEnumerable<TemplateSMS> GetAllTemplates()
        {
            return _templatesmsRepo.GetAll();
        }

        public TemplateSMS AddTemplate(string title, string text, bool isapproved)
        {
            TemplateSMS templateSMS = new TemplateSMS
            {
                Title = title,
                Text = text,
                isaproved = isapproved
            };
            _templatesmsRepo.Add(templateSMS);
            return templateSMS;
        }


        public TemplateSMS EditTemplate(string title, string text, bool isapproved, DateTime? updatedate, string updatedbyuser, int idtemplate)
        {
            TemplateSMS template_toedit = _templatesmsRepo.Get(idtemplate);
            if (template_toedit != null)
            {
                template_toedit.Title = title;
                template_toedit.Text = text;
                template_toedit.isaproved = isapproved;
                template_toedit.updatedate = updatedate;
                template_toedit.updatedbyuser = updatedbyuser;

                _templatesmsRepo.Complete();
                
            }
            else
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return template_toedit;
        }

        public IEnumerable<TemplateSMS> GetApprovedTemplates()
        {
            return _templatesmsRepo.GetAprovedTemplates();
        }

        public IEnumerable<TemplateSMS> GetTemplateInfo(int idtemplate)
        {
            var template = _templatesmsRepo.GetTemplateInfo(idtemplate);
            if (template == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return _templatesmsRepo.GetTemplateInfo(idtemplate);
        }

        public int Complete(TemplateSMS template)
        {
            if (template == _templatesmsRepo.Get(template.idtemplate))
            {
                return _templatesmsRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}