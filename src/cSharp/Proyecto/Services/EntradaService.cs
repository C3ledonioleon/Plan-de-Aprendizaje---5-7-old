using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

namespace Proyecto.Services
{
    public class EntradaService : IEntradaService
    {
        private readonly IEntradaRepository _entradaRepository;

        public EntradaService(IEntradaRepository entradaRepository)
        {
            _entradaRepository = entradaRepository;
        }

        public List<Entrada> ObtenerTodo()
        {
            return _entradaRepository.GetAll();
        }

        public Entrada? ObtenerPorId(int id)
        {
            return _entradaRepository.GetById(id);
        }

        public int AgregarEntrada(EntradaCreateDto entrada)
        {
            var nuevaEntrada = new Entrada
            {
                Precio = entrada.Precio,
                IdOrden = entrada.IdOrden,
                IdTarifa = entrada.IdTarifa,
                Estado = EstadoEntrada.Activa
            };
            return _entradaRepository.Add( nuevaEntrada);
        }
        public bool ActualizarEntrada(int id, Entrada entrada)
        {
            return _entradaRepository.Update(id, entrada);
        }

        public bool EliminarEntrada(int id)
        {
            return _entradaRepository.Delete(id);
        }
    }
}
