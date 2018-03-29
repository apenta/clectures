using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_APIs.Models
{
    public class Film
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description{ get; set; }
        public int YearReleased { get; set; }
        public string ImdbId { get; set; }
        public string Rating { get; set; }
    }
}