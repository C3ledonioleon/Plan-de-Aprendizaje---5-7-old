using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;

public class Entrada
{
    public int IdEntrada { get; set; }
    public int NumeroAsiento { get; set; }
    public decimal PrecioFinal { get; set; }
    public string Estado { get; set; }
    public QR CodigoQR { get; set; } 

    public Entrada(int idEntrada, int numeroAsiento, decimal precioFinal, string estado, QR codigoQR)
    {
        this.IdEntrada = idEntrada;
        this.NumeroAsiento = numeroAsiento;
        this.PrecioFinal = precioFinal;
        this.Estado = estado;
        this.CodigoQR = codigoQR;
    }
}