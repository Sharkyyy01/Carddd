using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CardIndex.Core.Entities;
using Npgsql;


namespace CardIndex.DataAccess.Postgres.Repositories
{
    public class EmployeeRepository
    {
        private static NpgsqlConnection InitConnection(string host, string username, string password, string database)
        {
            return new NpgsqlConnection($"Host={host};Username={username};Password={password};Database={database}");
        }

        public IEnumerable<Employee>? GetAll()
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM employee";

                    var employees = new List<Employee>();

                    var reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee();

                            employee.Id = reader.GetInt32(0);
                            employee.FirstName = reader.GetString(1);
                            employee.MiddleName = reader.GetString(2);
                            employee.LastName = reader.GetString(3);
                            employee.BirthDate = reader.GetDateTime(4);
                            employee.EmploymentDate = reader.GetDateTime(5);
                            employee.Position = reader.GetString(6);
                            employee.Department = reader.GetString(7);

                            employees.Add(employee);
                        }

                        return employees;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public void Save(Employee employee)
        {
            if (employee.Id == 0)
                Insert(employee);
            else
                Update(employee);
        }

        public void Insert(Employee employee)
        {
            using(var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using(var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO employee (first_name, middle_name, last_name, birth_date, employment_date, position, department) " +
                                      "VALUES (@first_name, @middle_name, @last_name, @birth_date, @employment_date, @position, @department)";
                    cmd.Parameters.AddWithValue("first_name", employee.FirstName);
                    cmd.Parameters.AddWithValue("middle_name", employee.MiddleName);
                    cmd.Parameters.AddWithValue("last_name", employee.LastName);
                    cmd.Parameters.AddWithValue("birth_date", employee.BirthDate);
                    cmd.Parameters.AddWithValue("employment_date", employee.EmploymentDate);
                    cmd.Parameters.AddWithValue("position", employee.Position);
                    cmd.Parameters.AddWithValue("department", employee.Department);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(Employee employee)
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE employee SET first_name = @first_name, middle_name = @middle_name, last_name = @last_name, birth_date = @birth_date, " +
                                      "employment_date = @employment_date, position = @position, department = @department WHERE id = @id";

                    cmd.Parameters.AddWithValue("first_name", employee.FirstName);
                    cmd.Parameters.AddWithValue("middle_name", employee.MiddleName);
                    cmd.Parameters.AddWithValue("last_name", employee.LastName);
                    cmd.Parameters.AddWithValue("birth_date", employee.BirthDate);
                    cmd.Parameters.AddWithValue("employment_date", employee.EmploymentDate);
                    cmd.Parameters.AddWithValue("position", employee.Position);
                    cmd.Parameters.AddWithValue("department", employee.Department);
                    cmd.Parameters.AddWithValue("id", employee.Id);

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
                    cmd.CommandText = $"DELETE FROM employee WHERE id = @id";
                    cmd.Parameters.AddWithValue("id", id);
                    int affectedRows = cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CreateEmployeeTable()
        {
            using (var conn = InitConnection("localhost", "postgres", "0000", "card_index"))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS employee(" +
                                      "id SERIAL PRIMARY KEY," +
                                      "first_name VARCHAR(255)," +
                                      "middle_name VARCHAR(255)," +
                                      "last_name VARCHAR(255)," +
                                      "birth_date TIMESTAMP," +
                                      "employment_date TIMESTAMP," +
                                      "position VARCHAR(255)," +
                                      "department VARCHAR(255)" +
                                      ")";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
