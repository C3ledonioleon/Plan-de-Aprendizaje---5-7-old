using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class LocalService : ILocalService
    {
        private readonly ILocalRepository _localRepository;

        public LocalService(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public List<Local> ObtenerTodo() => _localRepository.GetAll();

        public Local? ObtenerPorId(int id) => _localRepository.GetById(id);

        public int AgregarLocal(LocalCreateDto dto)
        {
            var nuevoLocal = new Local
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                CapacidadTotal = dto.CapacidadTotal
            };
            return _localRepository.Add(nuevoLocal);
        }

        public bool ActualizarLocal(int id, LocalUpdateDto dto)
        {
            var local = new Local
            {
                IdLocal = id,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                CapacidadTotal = dto.CapacidadTotal
            };
            return _localRepository.Update(id, local);
        }

        public bool EliminarLocal(int id) => _localRepository.Delete(id);
    }
}
