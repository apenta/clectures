using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Web.DAL;
using Trello.Web.Models;

namespace Trello.Web.Tests.TestDoubles
{
    // Create a Test Double class for the purpose of testing
    public class TrelloListDoubleDAL : ITrelloListDAL
    {
        public void AddCard(TrelloCard card)
        {
            
        }

        public List<TrelloList> GetLists()
        {
            return new List<TrelloList>();
        }

        public List<TrelloCard> SearchCards(string searchTerm)
        {
            return new List<TrelloCard>();
        }

        public void UpdateCard(TrelloCard card)
        {
           
        }
    }
}
