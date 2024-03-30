using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class PaqueteServicio
{
    public int IdPaqueteServicio { get; set; }

    public int IdPaquete { get; set; }

    public int IdServicio { get; set; }

    public double Costo { get; set; }

    public virtual Paquete IdPaqueteNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
