using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Atleta
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<EquipeAtleta> Equipeatleta { get; set; } = new List<EquipeAtleta>();
}
