using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Assento
{
    public int Id { get; set; }

    public string? Lado { get; set; }

    public string? Posicao { get; set; }

    public int Linha { get; set; }

    public virtual ICollection<AssentosPassageirosVoo> AssentosPassageirosVoos { get; set; } = new List<AssentosPassageirosVoo>();
}
