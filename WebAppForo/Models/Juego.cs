using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppForo.Models
{
    public partial class Juego
    {
        [Key]
        public int JuegoId { get; set; }

        [StringLength(100)]
        public string NombreJuego { get; set; } = null!;

        [StringLength(500)]
        public string DescJuego { get; set; } = null!;

        [StringLength(500)]
        public string? ImgJuego { get; set; }
        public int? Posicion { get; set; }
    }
}
