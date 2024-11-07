using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class AssentosPassageirosVoo
{
    public int IdVoo { get; set; }

    public int IdAssento { get; set; }

    public int? IdPassageiro { get; set; }

    public virtual Assento IdAssentoNavigation { get; set; } = null!;

    public virtual Passageiro? IdPassageiroNavigation { get; set; }

    public virtual Voo IdVooNavigation { get; set; } = null!;
}
