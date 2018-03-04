using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trello.Web.Models
{
    public class TrelloCard
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}