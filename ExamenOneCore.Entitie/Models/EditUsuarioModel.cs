using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ExamenOneCore.Entity.Models
{
    [DataContract]
    public partial class EditUsuarioModel
    {
        [DataMember(Name = "UserId")]
        public int UserId { get; set; }

        [DataMember(Name = "Usuario")]
        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [DataMember(Name = "CambiarPassword")]
        [Display(Name = "CambiarPassword")]
        public bool ChangePassword { get; set; }

        [DataMember(Name = "Password")]
        [StringLength(100, ErrorMessage = "La contraseña {0} debe de tener al menos {2} carácteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataMember(Name = "ConfirmPassword")]
        [StringLength(100, ErrorMessage = "La contraseña {0} debe de tener al menos {2} carácteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }

        [DataMember(Name = "Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "Sexo")]
        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        [DataMember(Name = "Estatus")]
        [Required]
        [Display(Name = "Estatus")]
        public bool Estatus { get; set; }

        [DataMember(Name = "FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [DataMember(Name = "FechaActualizacion")]
        public DateTime? FechaActualizacion { get; set; }
    }
}