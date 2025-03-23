using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class Apuestas
    {
        [Key]
        public int IdApuesta { get; set; }

        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [ForeignKey("Eventos")]
        public int IdEvento { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Monto { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Cuota { get; set; }

        [NotMapped]
        public decimal PosibleGanancia => Monto * Cuota;

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; }

        public DateTime FechaApuesta { get; set; } = DateTime.Now;

    }
}
