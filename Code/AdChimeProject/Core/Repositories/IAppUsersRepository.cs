using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface IAppUsersRepository
    {
        void Add(AppUsers entity);
        AppUsers GetUserbyEmail(string email);
        IEnumerable<AppUsers> GetAllUsers();
        int Complete();
    }
}
