using CoolWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoolWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var masks = GetMasks();
            return Json(masks, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Facts()
        {
            var model = new List<string>()
            {
                "Horses run fast",
                "Violin bows are made from horse fur",
                "Horses don't have fur, they have hair"
            };

            return PartialView(model);
        }


        private IList<HorseMask> GetMasks()
        {
            return new List<HorseMask>()
            {
                new HorseMask() { Id = 1, Name = "Sally", Url = "https://images-na.ssl-images-amazon.com/images/I/71hinjs7hpL._UX425_.jpg" },
                new HorseMask() { Id = 2, Name = "Lil' Sebastian", Url = "https://target.scene7.com/is/image/Target/15788616?wid=488&hei=488&fmt=pjpeg"}
            };
        }
    }
}