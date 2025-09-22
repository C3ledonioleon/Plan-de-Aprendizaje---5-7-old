namespace Proyecto.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }      // PRIMARY KEY, AUTO_INCREMENT
        public string Nombre { get; set; }      // NOT NULL
        public string DNI { get; set; }         // UNIQUE, NOT NULL
        public string Email { get; set; }       // NOT NULL
        public string Telefono { get; set; }
        
        
             // Constructor
        public Cliente(int idCliente, string nombre, string dni, string email, string telefono )
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.DNI = dni;
            this.Email = email;
            this.Telefono = telefono;
        }   // NULL permitido
    }
}

