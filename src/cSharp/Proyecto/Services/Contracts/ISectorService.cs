using Proyecto.Models;
using Proyecto.DTOs;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts;

    public interface ISectorService
    {
        List<Sector> ObtenerTodo();
        Sector? ObtenerPorId(int id);
        int AgregarSector(SectorCreateDto sector);         // Usar DTO para creación
        bool ActualizarSector(int id, SectorUpdateDto sector);  // Usar DTO para actualización
        bool EliminarSector(int id);
    }

