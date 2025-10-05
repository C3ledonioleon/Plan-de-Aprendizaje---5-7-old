using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface IOrdenService
    {
        List<Orden> ObtenerTodo();
        Orden? ObtenerPorId(int id);
        int AgregarOrden(OrdenCreateDto dto);
        bool ActualizarOrden(int id, OrdenUpdateDto dto);
        bool EliminarOrden(int id);
    }
}
