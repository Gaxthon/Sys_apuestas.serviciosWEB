using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class HistorialPagos
    {
        [Key]
        public int IdPago { get; set; }

        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [ForeignKey("MetodosPago")]
        public int IdMetodo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;
    }
}
