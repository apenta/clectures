using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WorldGeography.Tests.DAL
{
    [TestClass]    
    public class LanguageSqlDALTests
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;";


        [TestMethod]
        public void LanguagesByCountry_OfficialLanguages()
        {

        }

        [TestMethod]
        public void LanguagesByCountry_UnofficialLanguages()
        {

        }

        [TestMethod]
        public void AddLanguage_AddsLanguageIfRowDoesntExist()
        {

        }

        [TestMethod]
        public void AddLanguage_ThrowsExceptionIfRowExists()
        {

        }


        /// <summary>
        /// This is a "helper" method to insert a fake language.
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="name"></param>
        public static void InsertFakeLanguage(string countryCode, string name, bool isOfficial)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO countrylanguage VALUES (@countrycode, @language, @isOfficial, 10);", conn);
                cmd.Parameters.AddWithValue("@countrycode", countryCode);
                cmd.Parameters.AddWithValue("@language", name);
                cmd.Parameters.AddWithValue("@isOfficial", isOfficial);
                
                cmd.ExecuteNonQuery();
            }
        }
    }
}
