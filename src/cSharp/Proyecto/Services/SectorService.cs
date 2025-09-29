using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public List<Sector> ObtenerTodo ()
        {
           return _sectorRepository.GetAll();
        }

        public Sector? ObtenerPorId (int id)
        {
            return _sectorRepository.GetById(id);
        }

        public int AgregarSector (Sector sector)
        {
             return _sectorRepository.Add(sector);
        }

        public bool ActualizarSector(int id, Sector sector)
        {
            return _sectorRepository.Update(id, sector);
        }

        public bool EliminarSector (int id)
        {
             return _sectorRepository.Delete(id);
        }
    }
}