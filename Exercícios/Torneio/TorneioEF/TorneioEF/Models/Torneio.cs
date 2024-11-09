using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Torneio
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public virtual ICollection<Equipechavetorneio> Equipechavetorneios { get; set; } = new List<Equipechavetorneio>();

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
