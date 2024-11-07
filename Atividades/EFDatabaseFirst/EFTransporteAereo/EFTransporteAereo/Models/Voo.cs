using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Voo
{
    public int Id { get; set; }

    public int IdAeroportoOrigem { get; set; }

    public int IdAeroportoDestino { get; set; }

    public int IdAeronave { get; set; }

    public int IdPiloto { get; set; }

    public int NumAssentosOcupados { get; set; }

    public int? NumAssentosLivres { get; set; }

    public DateTime HorarioSaida { get; set; }

    public DateTime HorarioChegada { get; set; }

    public virtual ICollection<AssentosPassageirosVoo> AssentosPassageirosVoos { get; set; } = new List<AssentosPassageirosVoo>();

    public virtual Aeronave IdAeronaveNavigation { get; set; } = null!;

    public virtual Aeroporto IdAeroportoDestinoNavigation { get; set; } = null!;

    public virtual Aeroporto IdAeroportoOrigemNavigation { get; set; } = null!;

    public virtual Piloto IdPilotoNavigation { get; set; } = null!;

    public virtual ICollection<VoosEscala> VoosEscalas { get; set; } = new List<VoosEscala>();
}
