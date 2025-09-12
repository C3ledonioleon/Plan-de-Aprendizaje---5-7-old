using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;
public class Sector
{
    public int IdSector { get; set; }
    public string NombreSector { get; set; }
    public int CapacidadSector { get; set; }
    public decimal PrecioBase { get; set; }
    public int LocalId { get; set; }

    public Sector(int idSector, string nombreSector, int capacidadSector, decimal precioBase, int localId)
    {
        this.IdSector = idSector;
        this.NombreSector = nombreSector;
        this.CapacidadSector = capacidadSector;
        this.PrecioBase = precioBase;
        this.LocalId = localId;
    }
}