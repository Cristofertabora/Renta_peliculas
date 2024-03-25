using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renta_peliculas.CapaDatos
{
    internal class Conexion
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-69H1SBA\\SQLEXPRESS;Initial Catalog=tarea;Integrated Security=True;Encrypt=False;");
        public SqlConnection Conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar abrir la conexión: {ex.Message}");
                throw;
            }
        }
    }
}
