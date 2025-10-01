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
        public int IdEvento { get; set; }
        public int IdLocal { get; set; }
        public DateTime FechaHora { get; set; }

    }
}
