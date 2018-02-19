using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAL
    {
        private string connectionString;
        private const string SQL_InsertLanguage = @"insert into countrylanguage values (@countryCode, @language, @isOfficial, @percentage);";
        private const string SQL_LanguagesByCountry = @"select *  from countrylanguage  where countrycode = @countryCode and isofficial = @isOfficial;";
        private const string SQL_DeleteLanguage = "DELETE FROM countryLanguage WHERE countryCode = @countryCode AND language = @language";



        public LanguageSqlDAL(string databaseConnectionString)
        {
            connectionString = databaseConnectionString;
        }

        public List<Language> GetLanguages(string countryCode, bool officialOnly)
        {
            //1. Declare Output
            List<Language> output = new List<Language>();

            try
            {
                //2. Create connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //3. Open connection
                    conn.Open();

                    //4. Create the command
                    SqlCommand cmd = new SqlCommand(SQL_LanguagesByCountry, conn);

                    //5. Populate Parameters
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);
                    cmd.Parameters.AddWithValue("@isOfficial", officialOnly);

                    //6. Create the data reader
                    SqlDataReader reader = cmd.ExecuteReader();

                    //7. Loop through the rows in the reader
                    while (reader.Read())
                    {
                        //8. Populate a language object
                        Language language = new Language();
                        language.CountryCode = Convert.ToString(reader["countrycode"]);
                        language.IsOfficial = Convert.ToBoolean(reader["isofficial"]);
                        language.Name = Convert.ToString(reader["language"]);
                        language.Percentage = Convert.ToInt32(reader["percentage"]);

                        //9. Add to the output
                        output.Add(language);
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("An error occurred reading the database: " + ex.Message);
            }

            return output;
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            try
            {
                //1. Create the connection
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //2. Open the connection
                    conn.Open();

                    //3. Create the command
                    SqlCommand cmd = new SqlCommand(SQL_InsertLanguage, conn);

                    //4. Populate parameters
                    cmd.Parameters.AddWithValue("@countryCode", newLanguage.CountryCode);
                    cmd.Parameters.AddWithValue("@language", newLanguage.Name);
                    cmd.Parameters.AddWithValue("@isOfficial", newLanguage.IsOfficial);
                    cmd.Parameters.AddWithValue("@percentage", newLanguage.Percentage);

                    //5. Execute the query
                    cmd.ExecuteNonQuery();

                    //6. Return True
                    return true;
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("An error occurred reading the database: " + ex.Message);
                return false;
            }
        }

        public bool RemoveLanguage(Language deadLanguage)
        {
            throw new NotImplementedException();
        }
    }
}
