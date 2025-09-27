using System;
using System.Collections.Generic;

namespace Proyecto.Models
{
    public class Local
    {
        public int IdLocal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int CapacidadTotal { get; set; }

        // Constructor opcional con 'this'

        public Local(int idLocal, string nombre, string direccion, int capacidadTotal)
        {
            this.IdLocal = idLocal;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.CapacidadTotal = capacidadTotal;
        }
    }
}
