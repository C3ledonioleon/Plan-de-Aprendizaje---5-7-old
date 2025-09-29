using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class TarifaService : ITarifaService
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaService(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }

        public List<Tarifa> ObtenerTodo()
        {
            return _tarifaRepository.GetAll();
        }

        public Tarifa? ObtenerPorId (int id)
        {
            return _tarifaRepository.GetById(id);
        }

        public int AgregarTarifa (Tarifa tarifa)
        {
            return _tarifaRepository.Add(tarifa);
        }

        public bool ActualizarTarifa(int id, Tarifa tarifa)
        {
            return _tarifaRepository.Update(id, tarifa);
        }

        public bool EliminarTarifa(int id)
        {
            return _tarifaRepository.Delete(id);
        }
    }
}
