using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsPart2.Web.Models
{
    public class TrelloCard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
    }
}