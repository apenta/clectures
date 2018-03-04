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

        // GET: Home
        public ActionResult Index()
        {
            var dal = new TrelloListDAL();
            List<TrelloList> lists = dal.GetLists();

            return View("Index", lists);
        }
        
    }
}