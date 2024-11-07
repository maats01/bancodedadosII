using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Escala
{
    public int Id { get; set; }

    public int IdAeroporto { get; set; }

    public virtual Aeroporto IdAeroportoNavigation { get; set; } = null!;

    public virtual ICollection<VoosEscala> VoosEscalas { get; set; } = new List<VoosEscala>();
}
