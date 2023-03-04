using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class VarContactsService
    {

        private readonly IVarContactsRepository _varcontactsRepo;

        public VarContactsService(IVarContactsRepository varcontactsRepo)
        {
            _varcontactsRepo = varcontactsRepo;
        }

        public IEnumerable<tVarContact> GetAllVarContacts()
        {
            return _varcontactsRepo.GetAll();
        }


        public tVarContact GetVarbyId(int id)
        {
            tVarContact getvarb = _varcontactsRepo.Get(id);
            if (getvarb == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return getvarb;
        }

        public tVarContact AddVarContact(bool visible, string VarName, int colNumber, string colTypeType, string colTypeFilter)
        {
            tVarContact varcontact = new tVarContact
            {
                visible = visible,
                VarName = VarName,
                colNumber = colNumber,
                colTypeType = colTypeType,
                colTypeFilter = colTypeFilter
            };
            _varcontactsRepo.Add(varcontact);
            return varcontact;
        }

        public List<string> GetAllVariableNames()
        {
            return _varcontactsRepo.GetAllVariableNames();
        }

        public string GetColType_Variable(string variable)
        {
            return _varcontactsRepo.GetColType_Variable(variable);
        }


        public int Complete(tVarContact varcontact)
        {
            if (varcontact == _varcontactsRepo.Get(varcontact.idVar))
            {
                return _varcontactsRepo.Complete();
            }
            else
            {
                throw new ArgumentException("Nothing was saved.");
            }

        }


    }
}