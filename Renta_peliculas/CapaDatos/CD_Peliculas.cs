using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaDatos
{
    internal class CD_Peliculas
    {
        [Key]
        public int? PeliculaID { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(75)]
        public string Nombre { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(75)]
        public string Autores { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Date)]
        public DateTime FechaLngreso { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public int Existencia { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool Estado { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Range(0, double.MaxValue, ErrorMessage = "Precio de renta debe ser mayor a 0.")]
        [Column(TypeName = "Decimal(10, 2)")]
        public decimal PrecioRenta { get; set; }

        // Declare other class-level variables
        SqlCommand comando = new SqlCommand();
        Conexion conexion = new Conexion();
        public string Insertar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("insertar_pelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nombre", Nombre);
                        command.Parameters.AddWithValue("@autores", Autores);
                        command.Parameters.AddWithValue("@fechalngreso", FechaLngreso);
                        command.Parameters.AddWithValue("@existencia", Existencia);
                        command.Parameters.AddWithValue("@estado", Estado);
                        command.Parameters.AddWithValue("@preciorenta", PrecioRenta);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Modificar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("modificar_pelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", PeliculaID);
                        command.Parameters.AddWithValue("@nombre", Nombre);
                        command.Parameters.AddWithValue("@autores", Autores);
                        command.Parameters.AddWithValue("@fechalngreso", FechaLngreso);
                        command.Parameters.AddWithValue("@existencia", Existencia);
                        command.Parameters.AddWithValue("@estado", Estado);
                        command.Parameters.AddWithValue("@preciorenta", PrecioRenta);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("eliminar_pelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", PeliculaID);

                        command.ExecuteNonQuery();
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public DataSet Consultar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("consultar_peliculas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataSet Buscar(int id)
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("buscar_pelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", id);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
