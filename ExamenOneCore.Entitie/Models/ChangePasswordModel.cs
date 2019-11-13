using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamenOneCore.Entity.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [Display(Name = "UserId")]
        public int UserId { get; set; }

        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}