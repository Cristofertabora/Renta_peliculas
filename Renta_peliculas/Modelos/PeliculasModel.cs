using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    [Table("Peliculas")]
    public class PeliculasModel:EntidadBase
    {
        [Key]
        public int PeliculaId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombre { get; set; }
        
        [MaxLength(30)]
        public string Genero { get; set; }
        
        [MaxLength(75)]
        public string Autores { get; set; }
        public int Existencia { get; set; }
        public decimal PrecioRenta { get; set; }
        public bool Estado { get; set; }
    }
}
