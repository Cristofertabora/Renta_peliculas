using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Modelos
{
    [Table("Rentas")]
    public class RentaModel:EntidadBase
    {
        [Key]
        public int RentaId { get; set; }
        [Required]
        public int ClienteId { get; set; }
        public int PeliculaId { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaRetorno{ get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioRenta { get; set; }
    }
}
