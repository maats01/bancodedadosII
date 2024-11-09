using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class EquipeAtleta
{
    public int Id { get; set; }

    public int AtletaId { get; set; }

    public int EquipeId { get; set; }

    public virtual Atleta Atleta { get; set; } = null!;

    public virtual Equipe Equipe { get; set; } = null!;
}
