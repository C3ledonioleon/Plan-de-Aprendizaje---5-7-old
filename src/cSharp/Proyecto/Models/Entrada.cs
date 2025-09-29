namespace Proyecto.Models
{
    public class Entrada
    {
        public int IdEntrada { get; set; }
        public decimal Precio { get; set; }
        public int IdOrden { get; set; }
        public int IdTarifa { get; set; }
        public Orden? Orden { get; set; }
        public Tarifa? Tarifa { get; set; }
        public EstadoEntrada Estado { get; set; }
        Entrada()
        { }
    }

    public enum EstadoEntrada
    {
        Activa,
        Anulada
    }
}
