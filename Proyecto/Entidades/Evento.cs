using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;

    public class Evento
    {
        public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descripcion { get; set; }
        public string GeneroMusical { get; set; }
        public TimeSpan Duracion { get; set; }
    
         public Evento(int idEvento, string nombre, DateTime fecha, TimeSpan hora, string descripcion, string generoMusical, TimeSpan duracion)
        {
        this.IdEvento = idEvento;
        this.Nombre = nombre;
        this.Fecha = fecha;
        this.Hora = hora;
        this.Descripcion = descripcion;
        this.GeneroMusical = generoMusical;
        this.Duracion = duracion;
    }

}