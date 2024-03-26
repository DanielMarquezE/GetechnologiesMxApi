using System;
using System.Collections.Generic;

namespace Apí.Models
{
    public partial class Persona
    {
        public Persona()
        {
            
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Identificacion { get; set; }


    }
}
