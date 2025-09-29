using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Proyecto.DTOs
{
    public class ClienteCreateDto
    {
        [JsonPropertyName("dni")]
        public string DNI { get; set; }

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("telefono")]
        public string Telefono { get; set; }
    }
}
