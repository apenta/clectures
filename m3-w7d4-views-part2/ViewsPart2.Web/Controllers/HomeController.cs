using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewsPart2.Web.Models;

namespace ViewsPart2.Web.Controllers
{
    /*
    * Each Controller Action below responds to a request from a browser.
    * If the user visits http://localhost/Home/Index then the
    * Index Action will execute, returning the Index view.
    */
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            var lists = GetLists(); //1. imagine we called a DAL for our data

            return View(lists); //2. pass the model into our view
        }


        public ActionResult Detail(int id)
        {
            var list = GetLists().First(l => l.Id == id);

            return View(list);
        }



        // This is a private method that could be 
        // replaced by a DAL. We're keeping it simple today and just having it return
        // hard-coded data.
        private IList<TrelloList> GetLists()
        {
            IList<TrelloList> lists = new List<TrelloList>()
            {
                new TrelloList() { Id = 1,  Name = "To Do", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 1, Title = "Upload Assignment", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 2, Title = "Post GitHub Portfolio Page", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 3, Title = "C#", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 4, Title = "SQL", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 5, Title = "OOP Review", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 6, Title = "Abandon Java", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 7, Title = "Clean Garage", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 8, Title = "Learn Angular", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 9, Title = "Learn Vue", CreateDate = DateTime.Now},
                    }
                },
                new TrelloList() { Id = 2,  Name = "Completed", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 7, Title = "Teach Module 1", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 8, Title = "Teach Module 2", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 9, Title = "Module 1 Code Review", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 10, Title = "Async Talk", CreateDate = DateTime.Now},
                        new TrelloCard() { Id = 11, Title = "LINQ Talk", CreateDate = DateTime.Now},
                    }
                },
                new TrelloList() { Id = 3,  Name = "Pushed Off", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 12, Title = "Eat Breakfast", CreateDate = DateTime.Now},
                    }
                },
                 new TrelloList() { Id = 4,  Name = "Pushed Off", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 12, Title = "Eat Breakfast", CreateDate = DateTime.Now},
                    }
                },
                  new TrelloList() { Id = 5,  Name = "Pushed Off", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 12, Title = "Eat Breakfast", CreateDate = DateTime.Now},
                    }
                },
                   new TrelloList() { Id = 6,  Name = "Pushed Off", Cards = new List<TrelloCard>()
                    {
                        new TrelloCard() { Id = 12, Title = "Eat Breakfast", CreateDate = DateTime.Now},
                    }
                },
            };

            return lists;
        }


    }
}