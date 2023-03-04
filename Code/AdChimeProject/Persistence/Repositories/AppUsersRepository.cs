using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Repositories
{
    public class AppUsersRepository : IAppUsersRepository
    {
        protected readonly AdChimeContext Context;
        public AppUsersRepository(AdChimeContext context)
        {
            Context = context;

        }

        public void Add(AppUsers entity)
        {
            Context.Set<AppUsers>().Add(entity);
        }

        public AppUsers GetUserbyEmail(string email)
        {
            return AdChimeContext.AppUsers.Where(c => c.Email == email).FirstOrDefault();
        }

        public IEnumerable<AppUsers> GetAllUsers()
        {
            return AdChimeContext.AppUsers.ToList();
        }


        public AdChimeContext AdChimeContext
        {
            get { return Context as AdChimeContext;  }
        }

        public int Complete()
        {
            return AdChimeContext.SaveChanges();
        }

    }
}