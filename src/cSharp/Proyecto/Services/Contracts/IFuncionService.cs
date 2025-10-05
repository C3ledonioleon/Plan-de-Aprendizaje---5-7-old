using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

namespace Proyecto.Services.Contracts;

public interface IFuncionService
{
    List<Funcion> ObtenerTodo();
    Funcion? ObtenerPorId(int id);
    int AgregarFuncion(FuncionCreateDto funcion);
    bool ActualizarFuncion(int id, FuncionUpdateDto funcion); // <-- DTO en vez de modelo
    bool EliminarFuncion(int id);
    bool CancelarFuncion(int id); // opcional para simplificar el controller
}
