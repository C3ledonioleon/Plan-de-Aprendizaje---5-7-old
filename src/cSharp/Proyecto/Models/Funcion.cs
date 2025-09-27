using System;

namespace Proyecto.Models
{
    public class Funcion
    {
        public int IdFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEvento { get; set; }
        public int IdLocal { get; set; }
        public bool Cancelada { get; set; } // Para manejar cancelaciones

    }
}
