using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class TiposAeronave
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string DescTipo { get; set; } = null!;

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
}
