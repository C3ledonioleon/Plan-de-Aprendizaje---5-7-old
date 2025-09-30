using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Proyecto.DTOs
{
    public class OrdenCreateDto
    {

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
        
        [JsonPropertyName("clienteId")]
        public int IdCliente { get; set; }

        [JsonPropertyName("tarifaId")]
        public int IdTarifa { get; set; }
    }
}
