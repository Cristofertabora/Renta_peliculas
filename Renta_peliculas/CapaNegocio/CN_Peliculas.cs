using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Renta_peliculas.CapaNegocio
{
    internal class CN_Peliculas
    {
        public int PeliculaID { get; set; }
        public string Nombre { get; set; }
        public string Autores { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int Existencia { get; set; }
        public bool Estado { get; set; }
        public decimal PrecioRenta { get; set; }

        public static List<Peliculas> GetAllPeliculas(IDataReader reader)
        {
            var peliculas = new List<Peliculas>();
            while (reader.Read())
            {
                peliculas.Add(new Peliculas
                {
                    PeliculaID = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Autores = reader.GetString(2),
                    FechaLanzamiento = reader.GetDateTime(3),
                    Existencia = reader.GetInt32(4),
                    Estado = reader.GetBoolean(5),
                    PrecioRenta = reader.GetDecimal(6),
                });
            }
            return peliculas;
        }

        public static Peliculas GetPeliculaById(IDataReader reader)
        {
            if (!reader.Read())
            {
                return null;
            }

            return new Peliculas
            {
                PeliculaID = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Autores = reader.GetString(2),
                FechaLanzamiento = reader.GetDateTime(3),
                Existencia = reader.GetInt32(4),
                Estado = reader.GetBoolean(5),
                PrecioRenta = reader.GetDecimal(6),
            };
        }

        public void Create()
        {
            // Insert the new Pelicula into the database using the appropriate data access code
            // Set the PeliculaID property to the new value returned by the database
        }

        public void Update()
        {
            // Update the existing Pelicula in the database using the appropriate data access code
        }

        public void Delete()
        {
            // Delete the Pelicula from the database using the appropriate data access code
        }
    }

    public class PeliculaService
    {
        public List<Pelicula> GetAllPeliculas()
        {
            // Use the data access code to retrieve all the Peliculas from the database
            // Call the static factory method to map the data to the Pelicula objects
            return CapaDatos.CD_Peliculas.GetAllPeliculas(dbConnection.ExecuteReader("SELECT * FROM Peliculas"));
        }

        public CapaDatos.CD_Peliculas GetPeliculaById(int peliculaId) =>
            // Use the data access code to retrieve the Pelicula with the given ID from the database
            // Call the static factory method to map the data to the Pelicula objects
            CapaDatos.CD_Peliculas.GetPeliculaById(dbConnection.ExecuteReader($"SELECT * FROM Peliculas WHERE PeliculaID = {peliculaId}"));

        public void CreatePelicula(string nombre, string autores, DateTime fechaLanzamiento, int existencia, bool estado, decimal precioRenta)
        {
            // Use the data access code to insert the new Pelicula into the database
            // Create a new Pelicula object with the generated ID and other values
            // Call the Update() method on the Pelicula object to update its state in the database
        }

        public void UpdatePelicula(int peliculaId, string nombre, string autores, DateTime fechaLanzamiento, int existencia, bool estado, decimal precioRenta)
        {
            // Use the data access code to retrieve the Pelicula with the given ID from the database
            // Set the properties of the Pelicula object to the new values
            // Call the Update() method on the Pelicula object to update its state in the database
        }

        public void DeletePelicula(int peliculaId)
        {
            // Use thedata access code to retrieve the Pelicula with the given ID from the database
            // Call the Delete() method on the Pelicula object to delete it from the database
        }
    }
}
