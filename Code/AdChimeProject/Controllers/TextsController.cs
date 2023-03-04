using AdChimeProject.Core;
using AdChimeProject.Persistence;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdChimeProject.Core.Repositories;
using AdChimeProject.Persistence.Repositories;
using AdChimeProject.Persistence.Services;

namespace AdChimeProject.Controllers
{
    public class TextsController : Controller
    {

        protected readonly TemplateSMSService TemplatesmsService;
        public TextsController(TemplateSMSService templatesmsService)
        {
            TemplatesmsService = templatesmsService;
        }

        public TextsController()
        {
            TemplatesmsService = new TemplateSMSService(new TemplateSMSRepository(new AdChimeContext()));
        }



        public ActionResult MyTexts()
        {
            if (Session["email"] != null)
            {
                var all_templatesSMs = TemplatesmsService.GetAllTemplates();
                return View(all_templatesSMs);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        public ActionResult MyTextSelected(int id)
        {
            if (Session["email"] != null)
            {
                ViewBag.Current = "MyTexts";

                var all_templatesSMs = TemplatesmsService.GetAllTemplates();
                List<List<string>> all_templatesSMs_list = new List<List<string>>();
                foreach (var template in all_templatesSMs)
                {
                    List<string> lista_template = new List<string>();
                    lista_template.Add(template.idtemplate.ToString());
                    lista_template.Add(template.Title.ToString());

                    all_templatesSMs_list.Add(lista_template);
                };
                ViewBag.AllTemplates = all_templatesSMs_list;


                var modelselected = TemplatesmsService.GetTemplateById(id);


                return View(modelselected);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        [HttpPost]
        public ActionResult MyTextSelectedSave(TemplateSMS modeltemplatesms)
        {
            ViewBag.Current = "MyTexts";

            TemplateSMS edited_template = TemplatesmsService.EditTemplate(modeltemplatesms.Title, modeltemplatesms.Text, modeltemplatesms.isaproved, modeltemplatesms.updatedate, Session["Nome"].ToString(), modeltemplatesms.idtemplate);

            TemplatesmsService.Complete(edited_template);
            

            var all_templatesSMs = TemplatesmsService.GetAllTemplates();
            List<List<string>> all_templatesSMs_list = new List<List<string>>();
            foreach (var template in all_templatesSMs)
            {
                List<string> lista_template = new List<string>();
                lista_template.Add(template.idtemplate.ToString());
                lista_template.Add(template.Title.ToString());

                all_templatesSMs_list.Add(lista_template);
            };
            ViewBag.AllTemplates = all_templatesSMs_list;


            return RedirectToAction("MyTextSelected", new { id = modeltemplatesms.idtemplate });
        }


        public ActionResult NewText()
        {
            if (Session["email"] != null)
            {
                if (Session["isadmin"].ToString() == "True")
                {
                    ViewBag.Current = "MyTexts";
                    return View();
                }
                else
                {
                    return RedirectToAction("MyTexts");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        public ActionResult NewText(TemplateSMS template)
        {
            TemplateSMS newtemplate = TemplatesmsService.AddTemplate(template.Title, template.Text, true);
            TemplatesmsService.Complete(newtemplate);

            return RedirectToAction("MyTexts");
        }



        public ActionResult ChooseSMSText()
        {
            //return View(_unitOfWork.TemplateSMS.GetAllTemplates().ToPagedList(page ?? 1, 20));
            var all_templatesSMs = TemplatesmsService.GetAllTemplates();
            return View(all_templatesSMs);
        }

        public ActionResult ChooseSMSTextEdit()
        {
            var all_templatesSMs = TemplatesmsService.GetAllTemplates();
            return View(all_templatesSMs);
        }


    }
}