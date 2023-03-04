using AdChimeProject.Core;
using AdChimeProject.Persistence;
using Newtonsoft.Json.Linq;
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
    public class ContactsController : Controller
    {
        private readonly ContactsService _contactsService;
        private readonly ContactsVariablesService _contactsvariableSerivce;
        private readonly VarContactsService _varContactsService;

        public ContactsController(ContactsService contactsService, ContactsVariablesService contactsvariableService, VarContactsService varContactsService)
        {
            _contactsService = contactsService;
            _contactsvariableSerivce = contactsvariableService;
            _varContactsService = varContactsService;
        }

        public ContactsController()
        {
            _contactsService = new ContactsService(new ContactsRepository(new AdChimeContext()));
            _contactsvariableSerivce = new ContactsVariablesService(new ContactsVariablesRepository(new AdChimeContext()));
            _varContactsService = new VarContactsService(new VarContactsRepository(new AdChimeContext()));
        }

        private System.Data.DataTable getxlsData(string filexls, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            System.Data.DataTable _dtreturn = new System.Data.DataTable();
            DataTable dtSchema;
            var Sheetnecessaria = "";
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filexls + ";Extended Properties='Excel 12.0;HDR=" + header + ";IMEX=1;';"))
            {
                conn.Open();
                dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                Sheetnecessaria = dtSchema.Rows[0].Field<string>("TABLE_NAME").ToString();
            }

            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filexls + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;';";

            var adapter = new OleDbDataAdapter("SELECT * FROM [" + Sheetnecessaria + "] ", connectionString);
            var ds = new DataSet();

            adapter.Fill(_dtreturn);
            DataView dv = _dtreturn.DefaultView;
            _dtreturn = dv.ToTable();


            return _dtreturn;
        }

        private static DataTable ConvertCSVtoDataTable(string strFilePath, string delimiter)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                char delvalue;
                if (delimiter == "Semicolon")
                {
                    delvalue = ';';
                }
                else if (delimiter == "Tab")
                {
                    delvalue = '\t';
                }
                else
                {
                    delvalue = ',';
                }
                string[] headers = sr.ReadLine().Split(delvalue);
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(delvalue);
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;
        }



        public ActionResult MyContacts(string insertedcontacts, string message)
        {
            if (insertedcontacts != null)
            {
                ViewBag.insertedcontacts = insertedcontacts;
            }
            ViewBag.Current = "Contacts";


            List<string> lista_variaveis_opcionais = new List<string>();
            foreach (var col in _varContactsService.GetAllVariableNames())
            {
                lista_variaveis_opcionais.Add(col);
            }
            ViewBag.Colunas = lista_variaveis_opcionais;
            var allcontactswithoptin = _contactsService.GetContactsWithOptin();

            return View(allcontactswithoptin);
        }


        public ActionResult ImportContacts()
        {
            ViewBag.Current = "Contacts";

            List<List<string>> systemfields_importcontactmanual = new List<List<string>>();
            systemfields_importcontactmanual.Add(new List<string> { "Name", "text" });
            systemfields_importcontactmanual.Add(new List<string> { "LastName", "text" });
            systemfields_importcontactmanual.Add(new List<string> { "CountryCodePhone", "text" });
            systemfields_importcontactmanual.Add(new List<string> { "PhoneNumber", "number" });
            systemfields_importcontactmanual.Add(new List<string> { "Country", "text" });
            systemfields_importcontactmanual.Add(new List<string> { "isActive", "checkbox" });
            systemfields_importcontactmanual.Add(new List<string> { "Optin SMS", "checkbox" });

            foreach (var field in _varContactsService.GetAllVarContacts())
            {
                systemfields_importcontactmanual.Add(new List<string> { field.VarName, field.colTypeType });
            }
            ViewBag.Systemfields = systemfields_importcontactmanual;

            return View();
        }


        public ActionResult DeleteContact(int idcontact)
        {
            try
            {
                var contacto = _contactsService.GetContactById(idcontact);
                var variables_of_contact = _contactsvariableSerivce.GetAllVariablesOfCertainContact(idcontact);
                _contactsvariableSerivce.RemoveRange(variables_of_contact);
                _contactsService.RemovebyId(idcontact);

                return RedirectToAction("MyContacts", new { id = "Record deleted!" });
            }
            catch
            {
                return RedirectToAction("MyContacts", new { id = "Record not possible to delete. Please, try again later!" });
            }
        }

        public ActionResult DetailsContacts(int idcontact)
        {
            var details_contact = _contactsService.GetInfoContact(idcontact);

            return View(details_contact);
        }

        public ActionResult EditContacts(int idcontact)
        {
            var contact = _contactsService.GetInfoContactEdit(idcontact);

            return View(contact);
        }

        [HttpPost]
        public ActionResult EditContacts(Contacts contact_form)
        {
            //update student in DB using EntityFramework in real-life application

            //update list by removing old student and adding updated student for demo purpose
            var contacto = _contactsService.EditContact(contact_form.Name, contact_form.LastName, contact_form.bActive, contact_form.PhoneNumber,
                contact_form.CountryCodePhone, contact_form.Country, contact_form.optinSMS, Session["email"].ToString(), DateTime.Now, contact_form.idContact);
            

            return RedirectToAction("MyContacts", new { id = "Record updated!" });
        }

        public ActionResult AddNewField()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewField(string nameoffield, string fieldtype)
        {
            var varcontact = _varContactsService.AddVarContact(true, nameoffield, 0, fieldtype, "multipleoption");

            _varContactsService.Complete(varcontact);
            return RedirectToAction("MyContacts");
        }

        [HttpPost]
        public ActionResult ImportContactsFiles(HttpPostedFileBase fileee, string fielddelimiter, string typeofencoding, string updatedatausertext, string createrecipient_text, string createrecipient_bool)
        {
            Random rnd = new Random();
            int valor = rnd.Next(100000000, 999999999);
            var fileName = Path.GetFileName(fileee.FileName);
            var listafilename = fileName.Split('.');
            var filetypee = listafilename[listafilename.Count() - 1];

            if (fileee != null && fileee.ContentLength > 0)
            {
                string columns = "";
                var path = Path.Combine(Server.MapPath("~/Files/Contacts/"), valor.ToString() + fileName);
                fileee.SaveAs(path);

                if (filetypee == "xlsx" || filetypee == "xls")
                {
                    var xlsfile = getxlsData(Path.Combine(Server.MapPath("~/Files/Contacts/"), valor.ToString() + fileName), true);
                    foreach (var col in xlsfile.Columns)
                    {
                        columns = columns + col.ToString() + "##";
                    }

                }
                else if (filetypee == "csv" || filetypee == "txt")
                {
                    var xlsfile = ConvertCSVtoDataTable(Path.Combine(Server.MapPath("~/Files/Contacts/"), valor.ToString() + fileName), fielddelimiter);
                    foreach (var col in xlsfile.Columns)
                    {
                        columns = columns + col.ToString() + "##";
                    }
                }
                else
                {
                    columns = "##";
                }

                ViewBag.Current = "Contacts";

                if (createrecipient_bool == "false")
                {
                    createrecipient_text = "";
                }

                return RedirectToAction("ImportContactsMapping", new { columns = columns, filename = valor.ToString() + fileName, encodingtype = typeofencoding, updateuser = updatedatausertext, createrecipient = createrecipient_text });
            }

            else

            {
                return View();
            }
        }


        public ActionResult NewContact()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewContact(Contacts contact_form)
        {
            var contacto = _contactsService.AddContact(contact_form.Name, contact_form.LastName, contact_form.bActive,
                contact_form.PhoneNumber, contact_form.CountryCodePhone, contact_form.Country, contact_form.optinSMS,
                Session["email"].ToString());

            _contactsService.Complete(contacto);

            return RedirectToAction("MyContacts", new { id = "Record created!" });
        }


    }
}