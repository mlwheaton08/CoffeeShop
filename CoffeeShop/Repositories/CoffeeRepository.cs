using CoffeeShop.Models;
using Microsoft.Data.SqlClient;

namespace CoffeeShop.Repositories;

public class CoffeeRepository : ICoffeeRepository
{
    private readonly string _connectionString;
    public CoffeeRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    private SqlConnection Connection
    {
        get { return new SqlConnection(_connectionString); }
    }

    public List<Coffee> GetAll()
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select Id, Style, BeanVarietyId from Coffee";
                var reader = cmd.ExecuteReader();
                var coffees = new List<Coffee>();
                while (reader.Read())
                {
                    var coffee = new Coffee()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Style = reader.GetString(reader.GetOrdinal("Title")),
                        BeanVarietyId = reader.GetInt32(reader.GetOrdinal("Id")),
                    };
                    coffees.Add(coffee);
                }
                reader.Close();
                return coffees;
            }
        }
    }

    public Coffee Get(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select Id, Style, BeanVarietyId from Coffee where Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                var reader = cmd.ExecuteReader();

                Coffee coffee = null;
                if (reader.Read())
                {
                    coffee = new Coffee()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Style = reader.GetString(reader.GetOrdinal("Title")),
                        BeanVarietyId = reader.GetInt32(reader.GetOrdinal("Id")),
                    };
                }

                reader.Close();
                return coffee;
            }
        }
    }

    public void Add(Coffee coffee)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"insert into Coffee (Style, BeanVarietyId)
                                    output inserted.id
                                    values (@style, @beanVarietyId);";
                cmd.Parameters.AddWithValue("@style", coffee.Style);
                cmd.Parameters.AddWithValue("@beanVarietyId", coffee.BeanVarietyId);

                coffee.Id = (int)cmd.ExecuteScalar();
            }
        }
    }

    public void Update(Coffee coffee)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                        UPDATE Coffee 
                           SET Style = @style, 
                               BeanVarietyId = @beanVarietyId
                         WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", coffee.Id);
                cmd.Parameters.AddWithValue("@style", coffee.Style);
                cmd.Parameters.AddWithValue("@beanVarietyId", coffee.BeanVarietyId);

                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var conn = Connection)
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Coffee WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}