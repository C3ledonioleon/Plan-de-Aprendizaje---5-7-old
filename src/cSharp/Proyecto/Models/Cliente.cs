namespace Proyecto.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string DNI { get; set; }         // UNIQUE, NOT NULL // NOT NULL
        public string Nombre { get; set; }      // NOT NULL
        public string Telefono { get; set; }
        public List<Orden> Ordenes { get; set; }
        Cliente()
        { }
    }
    
}

