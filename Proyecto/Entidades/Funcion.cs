using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;
    public class Funcion
    {
        public int IdFuncion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Idioma { get; set; }
        public int EventoId { get; set; }

        public Funcion(int idFuncion, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string idioma, int eventoId)
        {
            this.IdFuncion = idFuncion;
            this.Fecha = fecha;
            this.HoraInicio = horaInicio;
            this.HoraFin = horaFin;
            this.Idioma = idioma;
            this.EventoId = eventoId;
        }
    }
