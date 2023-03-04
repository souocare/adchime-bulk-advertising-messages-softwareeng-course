using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class AppUserService
    {

        private readonly IAppUsersRepository _appuserRepo;

        public AppUserService(IAppUsersRepository appuserRepo)
        {
            _appuserRepo = appuserRepo;
        }

        public string GetStringSha256Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public AppUsers AddUser(string name, string email, string password, bool isadmin)
        {
            string finalpassword;
            if (String.IsNullOrEmpty(password))
                throw new ArgumentException("Password empty!");

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(textData);
                finalpassword =  BitConverter.ToString(hash).Replace("-", String.Empty);
            }
            AppUsers contact = new AppUsers
            {
                Name = name,
                Email = email,
                Password = finalpassword,
                iDLogin = Guid.NewGuid(),
                isadmin = isadmin
            };
            _appuserRepo.Add(contact);
            return contact;
        }


        public AppUsers EditUser(string name, string email, string password, bool? isadmin)
        {
            AppUsers user_toedit = _appuserRepo.GetUserbyEmail(email);
            if (user_toedit != null)
            {
                string finalpassword;
                if (String.IsNullOrEmpty(password))
                    throw new ArgumentException("Password empty!");

                using (var sha = new System.Security.Cryptography.SHA256Managed())
                {
                    byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
                    byte[] hash = sha.ComputeHash(textData);
                    finalpassword = BitConverter.ToString(hash).Replace("-", String.Empty);
                }
                user_toedit.Name = name;
                user_toedit.Email = email;
                user_toedit.Password = finalpassword;
                user_toedit.isadmin = isadmin;

                
            }
            else
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return user_toedit;
        }

        public AppUsers GetUserbyEmail(string email)
        {
            return _appuserRepo.GetUserbyEmail(email);
        }

        public IEnumerable<AppUsers> GetAllUsers()
        {
            return _appuserRepo.GetAllUsers();
        }


        public int Complete(AppUsers user)
        {
            if (user == _appuserRepo.GetUserbyEmail(user.Email))
            {
                return _appuserRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}