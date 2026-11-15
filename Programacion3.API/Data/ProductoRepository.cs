using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Programacion3.API.Models;

namespace Programacion3.API.Data;

public class ProductoRepository : IProductoRepository
{
    private readonly string _connectionString;

    public ProductoRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Programacion3")
            ?? throw new InvalidOperationException("No se encontró la connection string 'Programacion3'.");
    }

    public List<Producto> ObtenerTodos()
    {
        var productos = new List<Producto>();

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand("SELECT ID, Nombre, Precio, Stock FROM Productos", connection);

        connection.Open();
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            productos.Add(new Producto
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Precio = reader.GetDecimal(2),
                Stock = reader.GetInt32(3)
            });
        }

        return productos;
    }

    public Producto? ObtenerPorId(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(
            "SELECT ID, Nombre, Precio, Stock FROM Productos WHERE ID = @Id", connection);

        command.Parameters.AddWithValue("@Id", id);

        connection.Open();
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Producto
            {
                Id = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Precio = reader.GetDecimal(2),
                Stock = reader.GetInt32(3)
            };
        }

        return null;
    }
}