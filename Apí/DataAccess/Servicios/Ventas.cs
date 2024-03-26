using Apí.DataAccess.Interfaces;
using Apí.Models;

namespace Apí.DataAccess.Servicios
{
    public class Ventas : IFacturaRepository<Factura>, IDisposable
    {
        private GetechnologiesMxContext context;

        public Ventas(GetechnologiesMxContext context)
        {
            this.context = context;
        }

        public List<Factura> findFacturasByPersona(int idPersona)
        {
                return context.Facturas.Where(x => x.IdPersona==idPersona).ToList();

        }

        public Factura storageFactura(Factura factura)
        {
            try
            {
                    context.Facturas.Add(factura); 
                    Save();
                    return factura;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
