using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaDatos
{
    internal class CD_Renta
    {
        [Key]
        public int Rentald { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRenta { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaRetorno { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "Decimal(10,2)")]
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
                    using (SqlCommand command = new SqlCommand("insertar_renta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@fechaRenta", FechaRenta);
                        command.Parameters.AddWithValue("@fechaRetorno", FechaRetorno);
                        command.Parameters.AddWithValue("@cantidad", Cantidad);
                        command.Parameters.AddWithValue("@precioRenta", PrecioRenta);
                        
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
                    using (SqlCommand command = new SqlCommand("modificar_renta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@rentald", Rentald);
                        command.Parameters.AddWithValue("@fechaRenta", FechaRenta);
                        command.Parameters.AddWithValue("@fechaRetorno", FechaRetorno);
                        command.Parameters.AddWithValue("@cantidad", Cantidad);
                        command.Parameters.AddWithValue("@precioRenta", PrecioRenta);
                        

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
                    using (SqlCommand command = new SqlCommand("eliminar_renta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@rentald", Rentald);

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
                    using (SqlCommand command = new SqlCommand("consultar_rentas", connection))
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
                    using (SqlCommand command = new SqlCommand("buscar_renta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@rentald", id);
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
