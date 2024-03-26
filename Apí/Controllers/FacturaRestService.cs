using Apí.DataAccess.Interfaces;
using Apí.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apí.Controllers
{
    [ApiController]
    [Route("Facturas")]
    public class FacturaRestService : ControllerBase
    {
        private readonly IFacturaRepository<Factura> _context;

        public FacturaRestService(IFacturaRepository<Factura> context)
        {
            _context=context;
        }

        [HttpGet]
        [Route("getFacturasByIdPersona")]
        public List<Factura> getFacturasByIdPersona(int idPersona)
        {
            return _context.findFacturasByPersona(idPersona);
        }

        [HttpPost]
        [Route("createFactura")]
        public Factura createFactura(Factura factura)
        {
           return _context.storageFactura(factura);
        }

    }
}
