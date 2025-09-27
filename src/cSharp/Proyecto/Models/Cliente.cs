namespace Proyecto.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }      // PRIMARY KEY, AUTO_INCREMENT
        public string Nombre { get; set; }      // NOT NULL
        public string DNI { get; set; }         // UNIQUE, NOT NULL
        public string Email { get; set; }       // NOT NULL
        public string Telefono { get; set; }
        
    }
}

