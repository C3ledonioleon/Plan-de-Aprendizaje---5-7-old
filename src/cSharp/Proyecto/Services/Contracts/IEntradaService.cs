using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts
{
    public interface IEntradaService
    {
        List<Entrada> ObtenerTodo();
        Entrada? ObtenerPorId(int id);
        int AgregarEntrada(EntradaCreateDto entrada);
        bool ActualizarEntrada (int id, EntradaUpdateDto entrada);
        bool AnularEntrada(int id);
        bool EliminarEntrada(int id);
    }
}