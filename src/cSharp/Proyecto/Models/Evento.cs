namespace Proyecto.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }       
        public string Nombre { get; set; } = "";
        public string? Genero { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        }
    }

