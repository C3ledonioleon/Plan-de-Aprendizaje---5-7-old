using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Proyecto.Models; 
namespace Proyecto.DTOs
{
    public class FuncionCreateDto
    {
        [JsonPropertyName("dehcaHora")]
        public string FechaHora { get; set; }

        [JsonPropertyName("eventoId")]
        public string IdEvento { get; set; }

        [JsonPropertyName("localId")]
        public string IdLocal { get; set; }
    }
}
