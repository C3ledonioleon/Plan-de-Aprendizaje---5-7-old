using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts;

    public interface ILocalService
    {
        List<Local> ObtenerTodo();
        Local? ObtenerPorId(int id);
        int AgregarLocal(LocalCreateDto local);         // Usar DTO para creación
        bool ActualizarLocal(int id, LocalUpdateDto local);  // Usar DTO para actualización
        bool EliminarLocal(int id);
    }

