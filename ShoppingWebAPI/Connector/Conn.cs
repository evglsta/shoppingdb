using MySql.Data.MySqlClient;
using ShoppingWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebAPI.Connector
{
    public class Conn
    {
        public string ConnectionString { get; set; }
        public Conn(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM user", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User
                        {
                            Id = reader.GetInt32("id"),
                            Username = reader.GetString("username"),
                            Password = reader.GetString("password"),
                            Email = reader.GetString("email"),
                            Phone = reader.GetString("phone"),
                            Country = reader.GetString("country"),
                            City = reader.GetString("city"),
                            Postcode = reader.GetInt32("postcode"),
                            Name = reader.GetString("name"),
                            Address = reader.GetString("address")
                        });
                    }
                }
            }
            return list;
        }

        public List<Shopping> GetAllShopping()
        {
            List<Shopping> list = new List<Shopping>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM shopping", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Shopping
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            CreatedDate = reader.GetDateTime("createddate")
                        });
                    }
                }
            }
            return list;
        }

        public List<Shopping> GetShopping(string id)
        {
            List<Shopping> list = new List<Shopping>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM shopping WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Shopping
                        {
                            Id = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            CreatedDate = reader.GetDateTime("createddate")
                        });
                    }
                }
            }
            return list;
        }
    }
}
