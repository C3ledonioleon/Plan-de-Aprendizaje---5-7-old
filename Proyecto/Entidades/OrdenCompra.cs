using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Entidades;

public class OrdenCompra
{
    public int IdOrden { get; set; }
    public DateTime FechaCompra { get; set; }
    public decimal Total { get; set; }
    public string MedioPago { get; set; }
    public string Estado { get; set; }
    public string DNI { get; set; }

    public OrdenCompra(int idOrden, DateTime fechaCompra, decimal total, string medioPago, string estado, string dni)
    {
        this.IdOrden = idOrden;
        this.FechaCompra = fechaCompra;
        this.Total = total;
        this.MedioPago = medioPago;
        this.Estado = estado;
        this.DNI = dni;
    }
}
