using System;
using System.Collections.Generic;

namespace ApiGetechnologiesMx.Models
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
