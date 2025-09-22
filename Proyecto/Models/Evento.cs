namespace Proyecto.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }       
        public string Nombre { get; set; } = "";
        public string? Genero { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        // Constructor con parámetros
        public Evento(int idEvento, string nombre, string? genero, DateTime? fechaInicio, DateTime? fechaFin)
        {
            this.IdEvento = idEvento;
            this.Nombre = nombre;
            this.Genero = genero;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
        }

        }
    }

