using AdChimeProject.Persistence.Repositories;
using AdChimeProject.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdChimeProject.Controllers
{
    public class AdminController : Controller
    {

        private readonly AppUserService _appuserService;
        // GET: Admin

        public AdminController(AppUserService appuserService)
        {
            _appuserService = appuserService;
        }

        public AdminController()
        {
            _appuserService = new AppUserService(new AppUsersRepository(new AdChimeContext()));
        }

        public ActionResult AdminPage()
        {
            if (Session["idlogin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult ManageLogin()
        {
            return View();
        }

        public ActionResult EditUser(int iduser)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(int id, string name, string email, string password, bool isadmin)
        {
            var user = _appuserService.EditUser(name, email, password, isadmin);
            _appuserService.Complete(user);
            return View("ManageLogin");
        }


        public ActionResult AddUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string name, string email, string password, bool isadmin)
        {
            var user = _appuserService.AddUser(name, email, password, isadmin);
            _appuserService.Complete(user);
            return View("ManageLogin");
        }



        public ActionResult LoadSMSBalance()
        {
            if (Session["idlogin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult AddSMS(string nmbr)
        {
            return View();
        }
    }
}