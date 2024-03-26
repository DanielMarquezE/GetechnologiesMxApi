using Apí.DataAccess.Interfaces;
using Apí.Models;

namespace Apí.DataAccess.Servicios
{
    public class Directorio : IPersonaRepository<Persona>, IDisposable
    {
        private GetechnologiesMxContext context;

        public Directorio(GetechnologiesMxContext context)
        {
            this.context = context;
        }

        public List<Persona> findPersonas()
        {
            return context.Personas.ToList();
        }

        public Persona findPersonaByIdentificacion(int idPersona)
        {
            Persona persona = context.Personas.Where(x => x.Id==idPersona).FirstOrDefault();
            if (persona==null) persona = new Persona();
            return persona;
        }

        public Persona storagePersona(Persona persona)
        {
            try
            {
                context.Personas.Add(persona);
                Save();
                return persona;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Persona deletePersonaByIdentificacion(int idPersona)
        {
            Persona persona = context.Personas.Where(x => x.Id==idPersona).FirstOrDefault();
            if (persona==null)
            {
                return persona=new Persona();
            }
            else
            {
                RemoveFacturasDeLaPersona(persona.Id);
                context.Personas.Remove(persona);
                Save();
                return persona;
            }
        }

        private void RemoveFacturasDeLaPersona(int idPersona)
        {
            List<Factura> facturas= context.Facturas.Where(x => x.IdPersona==idPersona).ToList();
            foreach (var factura in facturas)
            {
                context.Facturas.Remove(factura);
                Save();
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
