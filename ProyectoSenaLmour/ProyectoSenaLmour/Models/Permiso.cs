using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? NomPermiso { get; set; }

    public virtual ICollection<PermisosRole> PermisosRoles { get; set; } = new List<PermisosRole>();
}
