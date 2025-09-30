using Proyecto.DTOs;
using Proyecto.Models;
using Proyecto.Repositories.Contracts;
using Proyecto.Services.Contracts;

public class OrdenService : IOrdenService
{
    private readonly IOrdenRepository _ordenRepository;

    public OrdenService(IOrdenRepository ordenRepository)
    {
        _ordenRepository = ordenRepository;
    }

    public List<Orden> ObtenerTodo()
    {
        return _ordenRepository.GetAll();
    }

    public Orden? ObtenerPorId (int id)
    {
        return _ordenRepository.GetById(id);
    }
    // Ahora recibe el DTO directamente
    public int AgregarOrden(OrdenCreateDto orden)
    {
        var nuevaOrden = new Orden
        {
            IdCliente = orden.IdCliente,
            IdTarifa = orden.IdTarifa,
            Total = orden.Total,
            Fecha = DateTime.Now,
            Estado = EstadoOrden.Creada
        };

        return _ordenRepository.Add(nuevaOrden);
    }

    public bool ActualizarOrden (int id, Orden orden)
    {
        return _ordenRepository.Update(id, orden);
    }
    
    public bool EliminarOrden (int id)
    {
        return _ordenRepository.Delete(id);
    }

}