using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAL
    {
        private string connectionString;

        public CitySqlDAL(string databaseconnectionString)
        {
            connectionString = databaseconnectionString;
        }


        public List<City> GetCitiesByCountryCode(string countryCode)
        {
            throw new NotImplementedException();
        }

    }
}
