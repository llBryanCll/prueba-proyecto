using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public int IdTipoServicio { get; set; }

    public string NomServicio { get; set; } = null!;

    public double Costo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleReservaServicio> DetalleReservaServicios { get; set; } = new List<DetalleReservaServicio>();

    public virtual TipoServicio IdTipoServicioNavigation { get; set; } = null!;

    public virtual ICollection<PaqueteServicio> PaqueteServicios { get; set; } = new List<PaqueteServicio>();
}
