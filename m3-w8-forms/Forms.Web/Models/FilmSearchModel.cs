using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Models
{
    /* 4. Create a model that the search page can use */
    public class FilmSearchModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public string Rating { get; set; }

        //public static IEnumerable<SelectListItem> Ratings = new List<SelectListItem>()
        //{
        //    new SelectListItem() { Text = "G", Value = "G"},
        //    new SelectListItem() { Text = "PG", Value = "PG"},
        //    new SelectListItem() { Text = }
        //};
    }
}