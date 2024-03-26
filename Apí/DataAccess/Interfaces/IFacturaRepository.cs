namespace Apí.DataAccess.Interfaces
{
    public interface IFacturaRepository<Factura> : IDisposable
    {
        List<Factura> findFacturasByPersona(int idPersona);
        Factura storageFactura(Factura persona);
        void Save();
    }
}
