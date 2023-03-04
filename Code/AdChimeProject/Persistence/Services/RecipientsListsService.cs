using AdChimeProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdChimeProject.Persistence.Services
{
    public class RecipientsListsService
    {

        private readonly IRecipientsListsRepository _recipientsListsRepo;

        public RecipientsListsService(IRecipientsListsRepository recipientsListsRepo)
        {
            _recipientsListsRepo = recipientsListsRepo;
        }


        public RecipientsLists GetRecipientListById(int id)
        {
            RecipientsLists recipientlist = _recipientsListsRepo.Get(id);
            if (recipientlist == null)
            {
                throw new ArgumentException("There is no such template with that id");
            }
            return recipientlist;
        }

        public IEnumerable<RecipientsLists> GetAllRecipientsLists()
        {
            return _recipientsListsRepo.GetRecipientsLists();
        }


        public int Complete(RecipientsLists recipientlist)
        {
            if (recipientlist == _recipientsListsRepo.Get(recipientlist.idrecipient))
            {
                return _recipientsListsRepo.Complete();
            } else
            {
                throw new ArgumentException("Nothing was saved.");
            }
            
        }


    }
}