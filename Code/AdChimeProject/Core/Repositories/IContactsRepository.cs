using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdChimeProject.Core.Repositories
{
    public interface IContactsRepository
    {
        Contacts Get(int id);
        IEnumerable<Contacts> GetAll();

        void Add(Contacts entity);

        void Remove(Contacts entity);

        IList<Contacts> GetContactsWithOptin();
        Contacts GetInfoContact(int id);
        Contacts GetInfoContactEdit(int id);
        int Complete();

    }
}
