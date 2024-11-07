using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Fabricante
{
    public int Id { get; set; }

    public string Fabricante1 { get; set; } = null!;

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
}
