using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Equipe
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<EquipeAtleta> Equipeatleta { get; set; } = new List<EquipeAtleta>();

    public virtual ICollection<Equipechavetorneio> Equipechavetorneios { get; set; } = new List<Equipechavetorneio>();

    public virtual ICollection<Partidaequipe> Partidaequipes { get; set; } = new List<Partidaequipe>();
}
