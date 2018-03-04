using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using Trello.Web.Models;

namespace Trello.Web.DAL
{
    public class TrelloListDAL : ITrelloListDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["TrelloDB"].ConnectionString;
        
        /// <summary>
        /// Updates a card in the database.
        /// </summary>
        /// <param name="card"></param>
        public void UpdateCard(TrelloCard card)
        {
            try
            {
                // Create a Transaction because 
                // we are going to Update card and card_categories table
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(
                            @"UPDATE card SET 
                            list_id = @listId,
                            title = @title, 
                            description = @description
                          WHERE id = @id;", conn);

                        cmd.Parameters.AddWithValue("@listId", card.ListId);
                        cmd.Parameters.AddWithValue("@title", card.Title);
                        cmd.Parameters.AddWithValue("@description", card.Description);
                        cmd.Parameters.AddWithValue("@id", card.Id);

                        // Delete all the existing categories
                        DeleteCategories(conn, card.Id);

                        // Insert all new categories
                        SaveCategories(conn, card);
                    }

                    scope.Complete();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

       
        /// <summary>
        /// Adds a new card to the database.
        /// </summary>        
        /// <param name="card"></param>
        public void AddCard(TrelloCard card)
        {
            try
            {
                // Create a transaction because we will update the 
                // card and the 
                using (TransactionScope scope = new TransactionScope())
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("INSERT INTO card VALUES (@listId, @title, @description, GETDATE());", conn);
                        cmd.Parameters.AddWithValue("@listId", card.ListId);
                        cmd.Parameters.AddWithValue("@title", card.Title);

                        if (String.IsNullOrEmpty(card.Description))
                        {
                            cmd.Parameters.AddWithValue("@description", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@description", card.Description);
                        }

                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("SELECT MAX(id) FROM card;", conn);
                        card.Id = Convert.ToInt32(cmd.ExecuteScalar());

                        SaveCategories(conn, card);
                    }

                    scope.Complete();
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public List<TrelloCard> SearchCards(string searchTerm)
        {
            List<TrelloCard> cards = new List<TrelloCard>();

            searchTerm = "%" + searchTerm + "%";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT card.id as card_id, card.list_id as list_id, card.title, card.description, card.createdate, card_categories.category
                        FROM card                        
                        LEFT JOIN card_categories ON card_categories.id = card.id
                        WHERE card.title LIKE @title
                        ORDER BY card_id;", conn);

                    cmd.Parameters.AddWithValue("@title", searchTerm);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int cardId = Convert.ToInt32(reader["card_id"]);

                        TrelloCard card = cards.LastOrDefault();
                        if (card == null || cardId != card.Id)
                        {
                            card = CreateCardFromReader(reader);
                            cards.Add(card);
                        }

                        if (reader["category"] != DBNull.Value)
                        {
                            card.Categories.Add(Convert.ToString(reader["category"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return cards;
        }

        public List<TrelloList> GetLists()
        {
            List<TrelloList> lists = new List<TrelloList>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"SELECT list.id as list_id, list.name, card.id as card_id, card.title, card.description, card.createdate, card_categories.category
                        FROM list
                        INNER JOIN card ON list.id = card.list_id
                        LEFT JOIN card_categories ON card_categories.id = card.id
                        ORDER BY list_id, card_id;", conn);

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        int listId = Convert.ToInt32(reader["list_id"]);
                        int cardId = Convert.ToInt32(reader["card_id"]);

                        TrelloList list = lists.LastOrDefault();
                        if (list == null || listId != list.Id)
                        {
                            list = CreateListFromReader(reader);
                            lists.Add(list);
                        }

                        TrelloCard card = list.Cards.LastOrDefault();
                        if (card == null || cardId != card.Id)
                        {
                            card = CreateCardFromReader(reader);
                            list.Cards.Add(card);
                        }

                        if (reader["category"] != DBNull.Value)
                        {
                            card.Categories.Add(Convert.ToString(reader["category"]));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }


            return lists;
        }

        private void SaveCategories(SqlConnection conn, TrelloCard card)
        {
            foreach (string category in card.Categories)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO card_categories VALUES (@id, @category)", conn);
                cmd.Parameters.AddWithValue("@id", card.Id);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.ExecuteNonQuery();
            }
        }

        private void DeleteCategories(SqlConnection conn, int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM card_categories WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private TrelloCard CreateCardFromReader(SqlDataReader reader)
        {
            TrelloCard card = new TrelloCard()
            {
                Id = Convert.ToInt32(reader["card_id"]),
                Title = Convert.ToString(reader["title"]),
                ListId = Convert.ToInt32(reader["list_id"]),
                Description = Convert.ToString(reader["description"]),
                CreateDate = Convert.ToDateTime(reader["createdate"])
            };
            return card;
        }

        private TrelloList CreateListFromReader(SqlDataReader reader)
        {
            TrelloList list = new TrelloList()
            {
                Id = Convert.ToInt32(reader["list_id"]),
                Name = Convert.ToString(reader["name"])
            };
            return list;
        }

    }
}