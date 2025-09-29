using Proyecto.Models;

namespace Proyecto.Services.Contracts
{
    public interface IEntradaService
    {
        List<Entrada> ObtenerTodo();
        Entrada? ObtenerPorId(int id);
        int AgregarEntrada(Entrada entrada);
        bool ActualizarEntrada (int id, Entrada entrada);
        bool EliminarEntrada(int id);
    }
}