﻿using AdChimeProject.Core;
using AdChimeProject.Persistence;
using AdChimeProject.Persistence.Repositories;
using AdChimeProject.Persistence.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdChimeProject.Controllers
{
    public class ListsController : Controller
    {

        private readonly RecipientsListsService _recipientlistService;
        private readonly ContactsService _contactsService;
        private readonly VarContactsService _varContactsService;
        private readonly ContactsVariablesService _contactsvariableService;
        public ListsController(RecipientsListsService recipientlistService, ContactsService contactsService, VarContactsService varContactsService, ContactsVariablesService contactsvariableService)
        {
            _recipientlistService = recipientlistService;
            _contactsService = contactsService;
            _varContactsService = varContactsService;
            _contactsvariableService = contactsvariableService;
        }


        public ListsController()
        {
            _recipientlistService = new RecipientsListsService(new RecipientsListsRepository(new AdChimeContext()));
            _contactsService = new ContactsService(new ContactsRepository(new AdChimeContext()));
            _varContactsService = new VarContactsService(new VarContactsRepository(new AdChimeContext()));
            _contactsvariableService = new ContactsVariablesService(new ContactsVariablesRepository(new AdChimeContext()));
        }


        public ActionResult MyLists(string errorname)
        {
            if (errorname == "sim")
            {
                ViewBag.MsgErroTitle = "sim";
            }
            ViewBag.Current = "MyLists";

            return View(_recipientlistService.GetAllRecipientsLists());
        }

        public ActionResult NewList(int? error)
        {
            if (error == 1)
            {
                ViewBag.MsgErroTitle = "sim";
            }


            var listadados = _contactsService.GetContactsWithOptin();
            List<string> systemfields = new List<string>();
            systemfields.Add("Name");
            systemfields.Add("LastName");
            systemfields.Add("CountryCodePhone");
            systemfields.Add("PhoneNumber");
            systemfields.Add("Country");


            foreach (var field in _varContactsService.GetAllVariableNames())
            {
                systemfields.Add(field);
            }

            ViewBag.Systemfields = systemfields;

            ViewBag.Countries = listadados.Select(x => x.Country).Distinct().ToList();
            ViewBag.Nomes = listadados.Select(x => x.Name).Distinct().ToList();

            ViewBag.Current = "MyLists";
            return View();
        }

        [HttpPost]
        public ActionResult NewList(string irecipientetexto, string output)
        {


            ViewBag.Current = "MyLists";

            return RedirectToAction("MyLists");
        }



        public string Addlog(string elementvalue, string idv)
        {

            var listadados = _contactsService.GetContactsWithOptin();


            var getcoltype = _varContactsService.GetColType_Variable(elementvalue);
            var hmtltext = "";
            if (getcoltype == null)
            {
                if (elementvalue == "Name" || elementvalue == "LastName" || elementvalue == "CountryCodePhone")
                {
                    hmtltext = "<input id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" type=\"text\" style=\"width: 100%; height: 100%; \" class=\"form-control\" />";
                }
                else if (elementvalue == "VeevaID")
                {
                    hmtltext = "<input id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" type=\"number\" style=\"width: 100%; height: 100%; \" class=\"form-control\" />";
                }
                else if (elementvalue == "Country")
                {
                    hmtltext = "<select id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" style=\"width: 100%; \" class=\"form-control select2-multiplethird_mudar\" multiple > ";
                    foreach (var country in listadados.Select(x => x.Country).Distinct().ToList())
                    {
                        hmtltext = hmtltext + " <option value=\"" + country + "\">" + country + "</option> ";
                    }
                    hmtltext = hmtltext + " </select> ";
                }
            }
            else
            {
                if (getcoltype == "integer")
                {
                    hmtltext = "<input id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" type=\"number\" style=\"width: 100%; height: 100%; \" class=\"form-control\" />";
                }
                else if (getcoltype == "string")
                {
                    hmtltext = "<input id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" type=\"text\" style=\"width: 100%; height: 100%; \" class=\"form-control\" />";
                }
                else if (getcoltype == "singleoption")
                {
                    hmtltext = "<select id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" style=\"width: 100%; \" class=\"form-control select2-multiplethird_mudar\"  > ";
                    var listadadospaneluser = _contactsvariableService.GetValues_Variable(elementvalue);
                    foreach (var lis in listadadospaneluser)
                    {
                        hmtltext = hmtltext + " <option value=\"" + lis + "\">" + lis + "</option> ";
                    }
                    hmtltext = hmtltext + " </select> ";
                }
                else if (getcoltype == "multipleotpion")
                {
                    hmtltext = "<select id=\"systemfields_" + idv.ToString() + "_3\" name=\"systemfields_" + idv.ToString() + "_3\" style=\"width: 100%; \" class=\"form-control select2-multiplethird_mudar\" multiple > ";
                    var listadadospaneluser = _contactsvariableService.GetValues_Variable(elementvalue);
                    foreach (var lis in listadadospaneluser)
                    {
                        hmtltext = hmtltext + " <option value=\"" + lis + "\">" + lis + "</option> ";
                    }
                    hmtltext = hmtltext + " </select> ";

                }
                else if (getcoltype == "date")
                {
                    hmtltext = "";
                }
                else
                {
                    hmtltext = "";
                }
            }

            return hmtltext;

        }


    }
}