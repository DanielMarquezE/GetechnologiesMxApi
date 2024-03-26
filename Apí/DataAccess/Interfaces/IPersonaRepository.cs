namespace Apí.DataAccess.Interfaces
{
    public interface IPersonaRepository<Persona> : IDisposable
    {
        List<Persona> findPersonas();
        Persona findPersonaByIdentificacion(int idPersona);
        Persona storagePersona(Persona persona);
        Persona deletePersonaByIdentificacion(int idPersona);
        void Save();
    }
}
