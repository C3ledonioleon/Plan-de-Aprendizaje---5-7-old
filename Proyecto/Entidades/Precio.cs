using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;

public class PrecioConcierto
{
    public decimal idPrecio { get; set; }
    public string TipoEntrada { get; set; }
    public int Stock { get; set; }          // Cantidad de entradas disponibles
    public decimal PrecioFinal { get; set; }

    public PrecioConcierto(decimal precioBase, string tipoEntrada, int stock)
    {
        this.idPrecio = precioBase;
        this.TipoEntrada = tipoEntrada;
        this.Stock = stock;
    }
}
