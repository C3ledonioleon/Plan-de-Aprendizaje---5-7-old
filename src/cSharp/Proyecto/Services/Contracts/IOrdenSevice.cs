using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface IOrdenService
    {

        List<Orden> ObtenerTodo();
        Orden? ObtenerPorId(int id);
        int AgregarOrden(OrdenCreateDto orden);
        bool ActualizarOrden(int id, Orden orden);
        bool EliminarOrden(int id);
    }
}