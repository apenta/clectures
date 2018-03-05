using Forms.Web.DAL;
using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forms.Web.Controllers
{
    public class FilmController : Controller
    {
        //8. Add a constructor to inject a IFilmDAL
        IFilmDAL dal;
        public FilmController(IFilmDAL dal)
        {
            this.dal = dal;
        }



        // GET: Film
        public ActionResult Index()
        {
            return View("Index");
        }


        // 1. Add a SearchResult Action
        public ActionResult SearchResult(FilmSearchModel filmSearch) //7. Add Model as a param
        {
            var films = dal.SearchFilms(filmSearch.Title, filmSearch.Description, filmSearch.ReleaseYear, filmSearch.MinLength, filmSearch.MaxLength, filmSearch.Rating);

            return View("SearchResult", films); //8. pass in the films as the model
        }
    }
}