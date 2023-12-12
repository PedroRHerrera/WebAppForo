using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebAppForo.Models;

namespace WebAppForo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Mensajes = new HashSet<Mensaje>();
        }

        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; } = null!;

        [StringLength(100)]
        public string UserMail { get; set; } = null!;

        [StringLength(20)]
        public string UserPassword { get; set; } = null!;

        public virtual ICollection<Mensaje> Mensajes { get; set; }
    }
}
