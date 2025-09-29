using Proyecto.Models;
namespace Proyecto.Services.Contracts
{
    public interface ILocalService
    {
        List<Local> ObtenerTodo ();
        Local? ObtenerPorId(int id);
        int AgregarLocal(Local local);
        bool ActualizarLocal(int id, Local local);
        bool EliminarLocal(int id);

    }
}