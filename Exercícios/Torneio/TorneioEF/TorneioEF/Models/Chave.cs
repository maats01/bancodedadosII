using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Chave
{
    public int Id { get; set; }

    public string? Chave1 { get; set; }

    public virtual ICollection<Equipechavetorneio> Equipechavetorneios { get; set; } = new List<Equipechavetorneio>();

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
