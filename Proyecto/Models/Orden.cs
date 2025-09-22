namespace Proyecto.Models
{
    public class Orden
    {
        public int IdOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public int IdCliente { get; set; }

        public Orden(int idOrden, DateTime fechaOrden, int idCliente)
        {
            this.IdOrden = idOrden;
            this.FechaOrden = fechaOrden;
            this.IdCliente = idCliente;
        }

        // Constructor vacío necesario para Dapper

    }
}
