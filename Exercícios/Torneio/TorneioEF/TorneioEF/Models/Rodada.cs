using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Rodada
{
    public int Id { get; set; }

    public string? Descricao { get; set; }

    public int? QtdEquipes { get; set; }

    public int? EquipesClassificadas { get; set; }

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
