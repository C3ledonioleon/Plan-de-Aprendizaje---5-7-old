using Proyecto.Models;
using Proyecto.Repositories.Contracts;

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
    public int AgregarOrden (Orden orden)
    {
        return _ordenRepository.Add(orden);
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