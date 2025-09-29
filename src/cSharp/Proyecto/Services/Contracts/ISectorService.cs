using Proyecto.Models;

public interface ISectorService
{

    List<Sector> ObtenerTodo();
    Sector? ObtenerPorId(int id);
    int AgregarSector(Sector sector);
    bool ActualizarSector(int id, Sector sector);
    bool EliminarSector(int id);
}