using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;
public class Local
{
    public int IdLocal { get; set; }
    public string NombreLocal { get; set; }
    public string Direccion { get; set; }
    public int CapacidadTotal { get; set; }

    public Local(int idLocal, string nombreLocal, string direccion, int capacidadTotal)
    {
        this.IdLocal = idLocal;
        this.NombreLocal = nombreLocal;
        this.Direccion = direccion;
        this.CapacidadTotal = capacidadTotal;
    }
}