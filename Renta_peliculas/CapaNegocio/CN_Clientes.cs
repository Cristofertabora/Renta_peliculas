using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaNegocio
{
    internal class CN_Clientes
    {
        public int ClienteID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Estado { get; set; }

        public static List<Cliente> GetAllClientes(IDataReader reader)
        {
            var clientes = new List<Cliente>();
            while (reader.Read())
            {
                clientes.Add(new Cliente
                {
                    ClienteID = reader.GetInt32(0),
                    Nombres = reader.GetString(1),
                    Apellidos = reader.GetString(2),
                    Estado = reader.GetBoolean(3),
                });
            }
            return clientes;
        }

        public static Cliente GetClienteById(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            return new Cliente
            {
                ClienteID = reader.GetInt32(0),
                Nombres = reader.GetString(1),
                Apellidos = reader.GetString(2),
                Estado = reader.GetBoolean(3),
            };
        }

        public void Create()
        {
            // Insert the new Cliente into the database using the appropriate data access code
            // Set the ClienteID property to the new value returned by the database
        }

        public void Update()
        {
            // Update the existing Cliente in the database using the appropriate data access code
        }

        public void Delete()
        {
            // Delete the Cliente from the database using the appropriate data access code
        }
    }

    public class ClienteService
    {
        public List<Cliente> GetAllClientes()
        {
            // Use the data access code to retrieve all the Clientes from the database
            // Call the static factory method to map the data to the Cliente objects
            return Cliente.GetAllClientes(dbConnection.ExecuteReader("SELECT * FROM Clientes"));
        }

        public Cliente GetClienteById(int clienteId) =>
            // Use the data access code to retrieve the Cliente with the given ID from the database
            // Call the static factory method to map the data to the Cliente objects
            Cliente.GetClienteById(DbConnection.ExecuteReader($"SELECT * FROM Clientes WHERE ClienteID = {clienteId}"));

        public void CreateCliente(string nombres, string apellidos)
        {
            // Use the data access code to insert the new Cliente into the database
            // Create a new Cliente object with the generated ID and other values
            // Call the Update() method on the Cliente object to update its state in the database
        }

        public void UpdateCliente(int clienteId, string nombres, string apellidos)
        {
            // Use the data access code to retrieve the Cliente with the given ID from the database
            // Set the properties of the Cliente object to the new values
            // Call the Update() method on the Cliente object to update its state in the database
        }

        public void DeleteCliente(int clienteId)
        {
            // Use the data access code to retrieve the Cliente with the given ID from the database
            // Call the Delete() method on the Cliente object to delete it from the database
        }
    }
}
