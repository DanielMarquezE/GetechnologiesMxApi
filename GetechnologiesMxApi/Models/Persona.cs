using System;
using System.Collections.Generic;

namespace GetechnologiesMxApi.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Identificacion { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
