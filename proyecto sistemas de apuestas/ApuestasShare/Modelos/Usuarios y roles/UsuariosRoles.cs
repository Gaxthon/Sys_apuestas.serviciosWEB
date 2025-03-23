using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasShare.Modelos
{
     public class UsuariosRoles
    {
        [ForeignKey("Usuarios")]
        public int IdUsuario { get; set; }

        [ForeignKey("Roles")]
        public int IdRol { get; set; }

       

    }
}
