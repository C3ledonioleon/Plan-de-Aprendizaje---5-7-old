using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

public class FuncionService : IFuncionService
{
    private readonly IFuncionRepository _funcionRepository;

    public FuncionService(IFuncionRepository funcionRepository)
    {
        _funcionRepository = funcionRepository;
    }

    public List<Funcion> ObtenerTodo()
    {
        return _funcionRepository.GetAll();
    }

    public Funcion?  ObtenerPorId(int id)
    {
        return _funcionRepository.GetById(id);
    }

    public int AgregarFuncion (FuncionCreateDto funcion)
    {
            var nuevaFuncion = new Funcion
            {
                IdEvento = funcion.IdEvento,
                IdLocal = funcion.IdLocal,
                FechaHora = funcion.FechaHora,
                Estado = EstadoFuncion.Pendiente // Estado inicial
            };
            return _funcionRepository.Add( nuevaFuncion );
    }

    public bool ActualizarFuncion (int id, Funcion funcion)
    {
        return _funcionRepository.Update(id, funcion);
    }

    public bool EliminarFuncion(int id)
    {
        return _funcionRepository.Delete(id);
    }
}
