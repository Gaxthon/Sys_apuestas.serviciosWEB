using System;

using System.ComponentModel.DataAnnotations;

namespace ApuestasShare.Modelos
{
    public class Roles
    {
        [Key]
        public int idRol { get; set; }

        [Required]
        [MaxLength(50)]
        public string nombreRol { get; set; }
    }
}
