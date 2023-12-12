using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAppForo.Models;

namespace WebAppForo.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ApplicationUser()
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


