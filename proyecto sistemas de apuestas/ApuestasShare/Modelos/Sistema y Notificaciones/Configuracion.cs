using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class Configuracion
    {

        [Key]
        public int IdConfiguracion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Clave { get; set; }

        [Required]
        [MaxLength(255)]
        public string Valor { get; set; }
    }
}
