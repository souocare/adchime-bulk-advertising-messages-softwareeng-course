using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AdChimeProject.Tests.Persistence.Repositories
{
    public class InMemoryAppUsersRepository : IAppUsersRepository
    {
        private List<AppUsers> _db = new List<AppUsers>();
        public Exception ExceptionToThrow { get; set; }

        public AppUsers GetUserbyEmail(string email)
        {
            return _db.Find(x => x.Email == email);
        }

        public IEnumerable<AppUsers> GetAllUsers()
        {
            return _db.ToList();
        }

        public void Add(AppUsers entity)
        {
            _db.Add(entity);
        }


        public int Complete()
        {
            return 1;
        }

    }
}