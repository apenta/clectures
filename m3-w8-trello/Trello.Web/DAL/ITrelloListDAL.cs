using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Web.Models;

namespace Trello.Web.DAL
{
    public interface ITrelloListDAL
    {
        
        void UpdateCard(TrelloCard card);

        void AddCard(TrelloCard card);

        List<TrelloCard> SearchCards(string searchTerm);

        List<TrelloList> GetLists();

    }
}
