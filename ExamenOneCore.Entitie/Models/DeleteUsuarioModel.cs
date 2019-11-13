using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ExamenOneCore.Entity.Models
{
    [DataContract]
    public partial class DeleteUsuarioModel
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }
    }
}