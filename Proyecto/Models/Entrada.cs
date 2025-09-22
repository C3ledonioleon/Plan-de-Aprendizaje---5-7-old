namespace Proyecto.Models
{
    public class Entrada
    {
        public int IdEntrada { get; set; }
        public decimal Precio { get; set; }
        public int IdOrden { get; set; }
        public int IdTarifa { get; set; }


        public Entrada(int idEntrada, decimal precio, int idOrden, int idTarifa)
        {
            this.IdEntrada = idEntrada;
            this.Precio = precio;
            this.IdOrden = idOrden;
            this.IdTarifa = idTarifa;
        }
    }
}
