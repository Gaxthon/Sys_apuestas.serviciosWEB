using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ApuestasShare.Modelos;
namespace sysApuestas__API
{
    public class SysApuestasContext : DbContext
    {


        public SysApuestasContext(DbContextOptions<SysApuestasContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolesPermisos>().HasKey(rp => new { rp.IdRol, rp.IdPermiso });  // 🔹 Definir clave primaria compuesta

            modelBuilder.Entity<UsuariosRoles>().HasKey( rp => new { rp.IdRol, rp.IdUsuario });


        }


        // USUARIOS Y ROLES 
        public DbSet<Usuarios> usuarios { get; set; }

        public DbSet<UsuariosRoles> usuariosRoles { get; set; }

        public DbSet<Roles> roles{ get; set; }

        public DbSet<RolesPermisos> rolesPermisos { get; set; }

        public DbSet<Permisos> permisos { get; set; }

        //****************************************************************************************


        //SISTEMA Y NOTIFICACIONES 

        public DbSet<Notificaciones> Notificaciones { get; set; }

        public DbSet<Configuracion> configuraciones { get; set; }


        //****************************************************************************************

        //EVENTOS Y APUESTAS 

        public DbSet<Apuestas> apuestas { get; set; }
        public DbSet<Eventos> eventos { get; set; }
        public DbSet<HistorialApuestas> HistorialApuestas { get; set; }
        public DbSet<ApuestasShare.Modelos.HistorialPagos> HistorialPagos { get; set; } = default!;
        public DbSet<ApuestasShare.Modelos.MetodosPago> MetodosPago { get; set; } = default!;
        public DbSet<ApuestasShare.Modelos.Transacciones> Transacciones { get; set; } = default!;

    }
}
