using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface ITarifaService
    {
        List<TarifaDto> ObtenerTodo();
        TarifaDto? ObtenerPorId(int id);
        int AgregarTarifa(TarifaCreateDto dto);
        bool ActualizarTarifa(int id, TarifaUpdateDto dto);
        bool EliminarTarifa(int id);
    }
}
