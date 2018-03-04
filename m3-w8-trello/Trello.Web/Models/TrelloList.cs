using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trello.Web.Models
{
    public class TrelloList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrelloCard> Cards { get; set; } = new List<TrelloCard>();
    }
}