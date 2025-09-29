using Proyecto.Models;

public interface IFuncionService
{

    List<Funcion> ObtenerTodo();
    Funcion? ObtenerPorId(int id);
    int AgregarFuncion(Funcion funcion);
    bool ActualizarFuncion(int id, Funcion funcion);
    bool EliminarFuncion(int id);
}