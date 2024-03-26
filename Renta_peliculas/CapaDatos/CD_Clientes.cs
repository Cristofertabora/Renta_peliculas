using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaDatos
{
    internal class CD_Clientes
    {
        [Key]
        public int? ClientelD { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(75)]
        public string Nombres { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [StringLength(75)]
        public string Apellidos { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool Estado { get; set; }

        // Declare other class-level variables
        SqlCommand comando = new SqlCommand();
        Conexion conexion = new Conexion();
        public string Insertar()
        {
            try
            {
                using (SqlConnection connection = conexion.Conectar())
                {
                    using (SqlCommand command = new SqlCommand("insertar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@nombres", Nombres);
                        command.Parameters.AddWithValue("@apellidos", Apellidos);
                        command.Parameters.AddWithValue("@estado", Estado);

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
                    using (SqlCommand command = new SqlCommand("modificar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", ClientelD);
                        command.Parameters.AddWithValue("@nombres", Nombres);
                        command.Parameters.AddWithValue("@apellidos", Apellidos);
                        command.Parameters.AddWithValue("@estado", Estado);

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
                    using (SqlCommand command = new SqlCommand("eliminar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", ClientelD);

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
                    using (SqlCommand command = new SqlCommand("consultar_clientes", connection))
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
                    using (SqlCommand command = new SqlCommand("buscar_cliente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@id", id);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet); return dataSet;
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
