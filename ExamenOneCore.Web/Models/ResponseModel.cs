using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenOneCore.Web.Models
{
    [Serializable]
    public class ResponseModel
    {
        public int ReturnCode { get; set; }
        public string Message { get; set; }
    }
}