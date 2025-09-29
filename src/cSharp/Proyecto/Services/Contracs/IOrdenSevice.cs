using Proyecto.Models;

public interface IOrdenService
{

    List<Orden> ObtenerTodo();
    Orden? ObtenerPorId(int id);
    int AgregarOrden(Orden orden);
    bool ActualizarOrden(int id, Orden orden);
    bool EliminarOrden(int id);
}