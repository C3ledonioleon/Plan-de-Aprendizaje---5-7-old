using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Proyecto.DTOs
{
    public class OrdenCreateDto
    {
        public decimal Total { get; set; }
        public int IdCliente { get; set; }

        [JsonPropertyName("tarifaId")]
        public int IdTarifa { get; set; }
    }
}
