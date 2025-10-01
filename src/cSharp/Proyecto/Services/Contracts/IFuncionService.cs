using Proyecto.DTOs;
using Proyecto.Models;
using System.Collections.Generic;

public interface IFuncionService
{

    List<Funcion> ObtenerTodo();
    Funcion? ObtenerPorId(int id);
    int AgregarFuncion(FuncionCreateDto funcion);
    bool ActualizarFuncion(int id, Funcion funcion);
    bool EliminarFuncion(int id);
}