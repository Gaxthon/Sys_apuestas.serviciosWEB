using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApuestasShare.Modelos
{
      public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Saldo { get; set; } = 0;

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}
