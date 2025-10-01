using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Proyecto.Models; 
using System;

namespace Proyecto.DTOs
{
    public class FuncionCreateDto
    {
        [JsonPropertyName("idEvento")]
        public int IdEvento { get; set; }

        [JsonPropertyName("idLocal")]
        public int IdLocal { get; set; }

        [JsonPropertyName("fechaHora")]
        public DateTime FechaHora { get; set; }

    }
}
