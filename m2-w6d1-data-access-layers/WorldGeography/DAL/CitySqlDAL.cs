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
            List<City> output = new List<City>();

            try
            {
                //1. Create the connection object
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    //2. Open the connecction
                    conn.Open();

                    //3. Create a command with the SQL Query and the connection
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countrycode = @countrycode ORDER BY district", conn);
                    
                    //4. Add country code parameter
                    cmd.Parameters.AddWithValue("@countrycode", countryCode);

                    //5. Execute the command to get a data reader back
                    SqlDataReader reader = cmd.ExecuteReader();

                    //6. Read each row
                    while (reader.Read())
                    {
                        //7. Turn each row into a city
                        City c = new City();
                        c.CityId = Convert.ToInt32(reader["id"]);
                        c.Name = Convert.ToString(reader["name"]);
                        c.CountryCode = Convert.ToString(reader["countrycode"]);
                        c.District = Convert.ToString(reader["district"]);
                        c.Population = Convert.ToInt32(reader["population"]);

                        //8. Add the city to the output list
                        output.Add(c);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("An error occurred reading from the database: " + ex.Message);
            }

            return output;
        }

    }
}
