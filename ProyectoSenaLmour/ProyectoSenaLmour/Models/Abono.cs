using System;
using System.Collections.Generic;

namespace ProyectoSenaLmour.Models;

public partial class Abono
{
    public int IdAbono { get; set; }

    public int IdReserva { get; set; }

    public DateTime FechaAbono { get; set; }

    public double? ValorDeuda { get; set; }

    public double Porcentaje { get; set; }

    public double Pendiente { get; set; }

    public double SubTotal { get; set; }

    public double Iva { get; set; }

    public double CantAbono { get; set; }

    public string? Estado { get; set; }

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
