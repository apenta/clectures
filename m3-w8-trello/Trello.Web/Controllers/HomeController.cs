using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trello.Web.DAL;
using Trello.Web.Models;

namespace Trello.Web.Controllers
{
    public class HomeController : Controller
    {
        // Create a private variable to hold the dal
        ITrelloListDAL dal;


        // Create a constructor that allows an ITrelloListDAL to be passed in
        public HomeController(ITrelloListDAL dal)
        {
            this.dal = dal;
        }


        // GET: Home
        public ActionResult Index()
        {
            //var dal = new TrelloListDAL(); <-- we are passed a class that implements ITrelloListDAL
            List<TrelloList> lists = dal.GetLists();
            
            return View("Index", lists);
        }
        
    }
}