using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class Habitacione
{
    public int IdHabitacion { get; set; }

    public int IdTipoHabitacion { get; set; }

    public string Nombre { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public double Costo { get; set; }

    public virtual TipoHabitacione IdTipoHabitacionNavigation { get; set; } = null!;

    public virtual ICollection<Paquete> Paquetes { get; set; } = new List<Paquete>();
}
