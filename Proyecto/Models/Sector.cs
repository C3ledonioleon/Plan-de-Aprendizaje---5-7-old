namespace Proyecto.Models
{
    public class Sector
    {
        public int IdSector { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public int IdLocal { get; set; }
        public Local Local { get; set; }

        public Sector (int idSector, string nombre, int capacidad, int idLocal)
        {
            this.IdSector = idSector;
            this.Nombre = nombre;
            this.Capacidad = capacidad;
            this.IdLocal = idLocal;
        }

    }
}
