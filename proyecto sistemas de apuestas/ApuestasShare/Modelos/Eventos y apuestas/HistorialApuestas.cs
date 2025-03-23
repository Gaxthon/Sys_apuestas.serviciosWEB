using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class HistorialApuestas
    {
        [Key]
        public int IdHistorial { get; set; }

        [ForeignKey("Apuestas")]
        public int IdApuesta { get; set; }

        [Required]
        [MaxLength(20)]
        public string EstadoAnterior { get; set; }

        [Required]
        [MaxLength(20)]
        public string EstadoNuevo { get; set; }

        public DateTime FechaCambio { get; set; } = DateTime.Now;

    }
}
