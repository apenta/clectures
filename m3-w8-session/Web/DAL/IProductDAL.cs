using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DAL
{
    public interface IProductDAL
    {
        IList<Product> GetProducts();
        Product GetProduct(int id);
    }
}