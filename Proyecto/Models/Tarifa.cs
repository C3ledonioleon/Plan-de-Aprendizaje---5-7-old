namespace Proyecto.Models
{
    public class Tarifa
    {
        public int IdTarifa { get; set; }
        public string MedioPago { get; set; }
        public int Stock { get; set; }
        public int IdSector { get; set; }
        public int IdFuncion { get; set; }

        public Tarifa() { }

        public Tarifa(int idTarifa, string medioPago, int stock, int idSector, int idFuncion)
        {
            this.IdTarifa = idTarifa;
            this.MedioPago = medioPago;
            this.Stock = stock;
            this.IdSector = idSector;
            this.IdFuncion = idFuncion;
        }
    }
}
