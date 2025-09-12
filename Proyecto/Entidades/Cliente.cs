using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;

    public class Cliente
{
    public string DNI { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Email { get; set; }
    public string Contrasenia { get; set; }
    public string Telefono { get; set; }
    public string Direccion { get; set; }
    public DateTime FechaRegistro { get; set; }

    public Cliente(string dni, string nombre, string apellido, string email, string contrasenia, string telefono, string direccion, DateTime fechaRegistro)
    {
        this.DNI = dni;
        this.Nombre = nombre;
        this.Apellido = apellido;
        this.Email = email;
        this.Contrasenia = contrasenia;
        this.Telefono = telefono;
        this.Direccion = direccion;
        this.FechaRegistro = fechaRegistro;
    }
}
