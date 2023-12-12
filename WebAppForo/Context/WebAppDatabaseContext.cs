using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebAppForo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAppForo.Context
{
    public class WebAppDatabaseContext : IdentityDbContext
    {

        public WebAppDatabaseContext()
        {
        }
        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext>options) : base(options)
        {
        }
        public virtual DbSet<Juego> Juegos { get; set; } = null!;
        public virtual DbSet<Mensaje> Mensajes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
    }
}

