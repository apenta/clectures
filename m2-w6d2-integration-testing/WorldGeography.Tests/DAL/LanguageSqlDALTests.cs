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
    public class LanguageSqlDALTests
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;";


        [TestMethod]
        public void LanguagesByCountry_OfficialLanguages()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                // Arrange
                CountrySqlDALTests.InsertFakeCountry("JRT", "Joshtopia", "North America");
                LanguageSqlDALTests.InsertFakeLanguage("JRT", "Official Language", true);
                LanguageSqlDALTests.InsertFakeLanguage("JRT", "Unofficial Languauge", false);
                LanguageSqlDAL testClass = new LanguageSqlDAL(connectionString);

                // Act
                List<Language> languages = testClass.GetLanguages("JRT", true);

                // Assert
                Assert.AreEqual(1, languages.Count);
                Assert.AreEqual("Official Language", languages[0].Name);
            }
        }

        [TestMethod]
        public void LanguagesByCountry_UnofficialLanguages()
        {

        }

        [TestMethod]
        public void AddLanguage_AddsLanguageIfRowDoesntExist()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                //Arrange
                CountrySqlDALTests.InsertFakeCountry("JRT", "Fake Country", "North America");
                LanguageSqlDAL testClass = new LanguageSqlDAL(connectionString);
                Language newLanguage = new Language();
                newLanguage.CountryCode = "JRT";
                newLanguage.Name = "TEST LANGUAGE";
                newLanguage.IsOfficial = true;
                newLanguage.Percentage = 100;

                //Act
                bool output = testClass.AddNewLanguage(newLanguage);

                //Assert
                Assert.IsTrue(output);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void AddLanguage_ThrowsExceptionIfRowExists()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                //Arrange
                CountrySqlDALTests.InsertFakeCountry("JRT", "Fake Country", "North America");
                LanguageSqlDALTests.InsertFakeLanguage("JRT", "TEST LANGUAGE", true);
                LanguageSqlDAL testClass = new LanguageSqlDAL(connectionString);
                Language newLanguage = new Language();
                newLanguage.CountryCode = "JRT";
                newLanguage.Name = "TEST LANGUAGE";
                newLanguage.IsOfficial = true;
                newLanguage.Percentage = 100;

                //Act
                bool output = testClass.AddNewLanguage(newLanguage);

                
            }
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
