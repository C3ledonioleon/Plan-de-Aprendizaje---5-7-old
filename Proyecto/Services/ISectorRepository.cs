using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Interfaces
{
    public interface ISectorRepository
    {
        int CrearSector(Sector sector);
        IEnumerable<Sector> ObtenerSectoresPorLocal(int localId);
        bool ActualizarSector(Sector sector);
        bool EliminarSector(int sectorId);
    }
}
