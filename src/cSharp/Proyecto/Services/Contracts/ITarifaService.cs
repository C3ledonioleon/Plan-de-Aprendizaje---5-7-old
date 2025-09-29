using Proyecto.Models;
namespace Proyecto.Services.Contracts
{
    public interface ITarifaService
    {
        List<Tarifa> ObtenerTodo();
        Tarifa? ObtenerPorId(int id);
        int AgregarTarifa(Tarifa tarifa);
        bool ActualizarTarifa(int id, Tarifa tarifa);
        bool EliminarTarifa(int id);
    }
}