using System;

namespace Proyecto.Models
{
    public class Funcion
    {
        public int IdFuncion { get; set; }
        public int IdEvento { get; set; }
        public int IdLocal { get; set; }
        public DateTime FechaHora { get; set; }
        public EstadoFuncion Estado { get; set; }
        public Evento? Evento { get; set; }
        public Local? Local { get; set; }
        Funcion()
        { }
    }
    public enum EstadoFuncion
    {
        Pendiente,  // Función creada y pendiente de realizarse
        Cancelada,   // Función cancelada
        Finalizada   // Función realizada
    }
}
