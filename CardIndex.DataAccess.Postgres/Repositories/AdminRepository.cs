using CardIndex.Core.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardIndex.DataAccess.Postgres.Repositories
{
    public class AdminRepository
    {
        private static NpgsqlConnection InitConnection(string host, string username, string password, string database)
        {
            return new NpgsqlConnection($"Host={host};Username={username};Password={password};Database={database}");
        }

        public IEnumerable<Admin>? GetAll()
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM admin";

                    var admins = new List<Admin>();

                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var admin = new Admin();

                            admin.Id = reader.GetInt32(0);
                            admin.Name = reader.GetString(1);
                            admin.Password = reader.GetString(2);
                            admin.Salt = reader.GetString(3);

                            admins.Add(admin);
                        }

                        return admins;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Insert(Admin admin)
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO admin (name, password, salt) " +
                                      "VALUES (@name, @password, @salt)";

                    cmd.Parameters.AddWithValue("name", admin.Name);
                    cmd.Parameters.AddWithValue("password", admin.Password);
                    cmd.Parameters.AddWithValue("salt", admin.Salt);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Admin admin)
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE admin SET name = @name, password = @password, salt = @salt WHERE id = @id";

                    cmd.Parameters.AddWithValue("name", admin.Name);
                    cmd.Parameters.AddWithValue("password", admin.Password);
                    cmd.Parameters.AddWithValue("salt", admin.Salt);
                    cmd.Parameters.AddWithValue("id", admin.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Delete(int id)
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = $"DELETE FROM admin WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    int affectedRows = cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateAdminTable()
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS admin(" +
                                      "id SERIAL PRIMARY KEY," +
                                      "name VARCHAR(255) UNIQUE" +
                                      "password VARCHAR(255)" +
                                      "salt VARCHAR (255)" +
                                      ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Admin? SelectByName(string name)
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM admin WHERE name = @name";
                    cmd.Parameters.AddWithValue("name", name);

                    using (var reader =  cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            Admin admin = new Admin();
                            admin.Id = reader.GetInt32(0);
                            admin.Name = reader.GetString(1);
                            admin.Password = reader.GetString(2);
                            admin.Salt = reader.GetString(3);

                            return admin;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

    }
}
