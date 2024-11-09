using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Modalidade
{
    public int Id { get; set; }

    public string? Modalidade1 { get; set; }

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
