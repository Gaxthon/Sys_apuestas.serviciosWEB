using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class MetodosPago
    {
        [Key]
        public int IdMetodo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
