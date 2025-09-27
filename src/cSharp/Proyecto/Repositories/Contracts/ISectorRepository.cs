using Proyecto.Models;

namespace Proyecto.Repositories.Contracts
{
    public interface ISectorRepository
    {
        int CrearSector(Sector sector);
        IEnumerable<Sector> ObtenerSectoresPorLocal(int localId);
        bool ActualizarSector(Sector sector);
        bool EliminarSector(int sectorId);
    }
}
