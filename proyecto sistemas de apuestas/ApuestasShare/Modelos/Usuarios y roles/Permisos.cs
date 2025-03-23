using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
    public class Permisos
    {
        [Key]
        public int idPermiso { get; set; }

        [Required]
        [MaxLength(255)]
        public string descripcion { get; set; }
    }
}
