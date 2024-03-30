using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string? NomTipoDcumento { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
