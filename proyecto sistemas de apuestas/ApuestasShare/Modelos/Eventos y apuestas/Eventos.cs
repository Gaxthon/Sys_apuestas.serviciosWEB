using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class Eventos
    {
        [Key]
        public int IdEvento { get; set; }

        [Required]
        [StringLength(150)]
        public string NombreEvento { get; set; }

        public DateTime FechaEvento { get; set; }

        [Required]
        [MaxLength(20)]
        public string Estado { get; set; }

    }
}
