using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAppForo.Models;

namespace WebAppForo.Models
{
    public partial class Mensaje
    {
        [Key]
        public int MsgId { get; set; }

        [StringLength(500)]
        public string Texto { get; set; } = null!;

        [StringLength(500)]
        public string? Imagen { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public Usuario? User { get; set; } = null!;
    }
}
