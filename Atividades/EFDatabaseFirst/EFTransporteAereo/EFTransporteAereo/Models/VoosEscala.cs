using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class VoosEscala
{
    public int Id { get; set; }

    public int IdVoo { get; set; }

    public int IdEscala { get; set; }

    public DateTime HorarioChegada { get; set; }

    public DateTime HorarioSaida { get; set; }

    public virtual Escala IdEscalaNavigation { get; set; } = null!;

    public virtual Voo IdVooNavigation { get; set; } = null!;
}
