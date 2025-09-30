using Proyecto.Models;
using Proyecto.Repositories.Contracts;

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

    public int AgregarFuncion (FucionCreateDto fucion)
    {
            var nuevaEntrada = new Funcion
            {
                Precio = funcion.Precio,
                IdOrden = funcion.IdOrden,
                IdTarifa = funcion.IdTarifa,
                Estado = EstadoEntrada.Activa
            };
            return _entradaRepository.Add( nuevaEntrada);
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
