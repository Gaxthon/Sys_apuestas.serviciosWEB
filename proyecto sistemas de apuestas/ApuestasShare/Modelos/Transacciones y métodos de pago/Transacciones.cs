using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class Transacciones
    {
        [Key]
        public int IdTransaccion { get; set; }

        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(10)]
        public string Tipo { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        public DateTime FechaTransaccion { get; set; } = DateTime.Now;

    }
}
