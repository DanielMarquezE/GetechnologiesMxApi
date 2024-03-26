using System;
using System.Collections.Generic;

namespace GetechnologiesMxApi.Models
{
    public partial class Factura
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public int? IdPersona { get; set; }

        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
