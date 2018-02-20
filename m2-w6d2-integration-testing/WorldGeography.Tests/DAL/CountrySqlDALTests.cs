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
    public class CountrySqlDALTests
    {
        const string connectionString = @"Server=.\SQLEXPRESS;Database=World;Trusted_Connection=True;";


        


        /// <summary>
        /// This is a "helper" method for testing. It inserts a fake country.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="continent"></param>
        public static void InsertFakeCountry(string code, string name, string continent)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO country VALUES (@code, @name, @continent, 'Middle East', 100, null, 100, null, null, null, @name, 'Test Government', 'Test Leader', null, @code2)", conn);
                cmd.Parameters.AddWithValue("@code", code);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@continent", continent);
                cmd.Parameters.AddWithValue("@code2", code.Substring(0, 2));

                cmd.ExecuteNonQuery();
            }
        }

    }
}
