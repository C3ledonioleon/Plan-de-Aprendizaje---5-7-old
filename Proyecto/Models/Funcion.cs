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

        public Funcion(int idFuncion, DateTime fecha, int idEvento, int idLocal, bool cancelada = false)
        {
            this.IdFuncion = idFuncion;
            this.Fecha = fecha;
            this.IdEvento = idEvento;
            this.IdLocal = idLocal;
            this.Cancelada = cancelada;
        }
    }
}
