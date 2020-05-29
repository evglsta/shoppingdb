using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebAPI.Models
{
    public class User
    {
        public User()
        {

        }

        public string ConnectionString { get; set; }
        public User(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Postcode { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public async Task Add()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user(username, password, email, phone, country, city, postcode, name, address) VALUE (username, password, email, phone, country, city, postcode, name, address)", conn);
                //BindParams(cmd);
                await cmd.ExecuteNonQueryAsync();
                Id = (int)cmd.LastInsertedId;
            }
        }
    }
}
