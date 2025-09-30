using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Proyecto.DTOs
{
    public class EntradaCreateDto
    {
        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }

        [JsonPropertyName("ordenId")]
        public int IdOrden { get; set; }

        [JsonPropertyName("tarifaId")]
        public int IdTarifa { get; set; }
    }
}
