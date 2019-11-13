using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExamenOneCore.Entity.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El usuario es requerido.")]
        [RegularExpression(@"^[a-zA-Z0-9\.]*$", ErrorMessage = "Ingrese solo letras, números y punto")]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [StringLength(100, ErrorMessage = "La constraseña {0} debe de tener al menos {2} carácteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}