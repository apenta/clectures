using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WorldGeography.DAL;
using WorldGeography.Models;

namespace WorldGeography.Tests.DAL
{
    [TestClass]
    public class CitySqlDALTests
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;";


        [TestMethod]
        public void CitiesByCountryCode_Country_With_NoCities()
        {

        }

        [TestMethod]
        public void CitiesByCountryCode_Country_With_Cities()
        {
            // Rolls back the data when done with the test.
            using (TransactionScope transaction = new TransactionScope())
            {
                //Arrange
                CountrySqlDALTests.InsertFakeCountry("JRT", "Joshtopia", "North America");
                int cityId = CitySqlDALTests.InsertFakeCity("Joshville", "JRT");
                CitySqlDAL testClass = new CitySqlDAL(connectionString);

                //Act
                List<City> cities = testClass.GetCitiesByCountryCode("JRT");

                //Assert
                Assert.AreEqual(1, cities.Count);
                Assert.AreEqual("Joshville", cities[0].Name);
                Assert.AreEqual(cityId, cities[0].CityId);
            }            
        }

        /// <summary>
        /// This is a "helper" method for testing. It inserts a fake city.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public static int InsertFakeCity(string name, string countryCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert Fake City
                SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countrycode, 'Test District', 1)", conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@countrycode", countryCode);

                cmd.ExecuteNonQuery();

                // Get Its ID
                cmd = new SqlCommand("SELECT MAX(id) FROM city;", conn);

                // Execute Scalar is used to return ONE value from the query
                int newId = Convert.ToInt32(cmd.ExecuteScalar());

                return newId;
            }
        }
    }
}
