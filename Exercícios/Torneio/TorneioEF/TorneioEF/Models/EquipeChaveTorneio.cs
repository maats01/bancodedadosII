using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Equipechavetorneio
{
    public int Id { get; set; }

    public int TorneioId { get; set; }

    public int ChaveId { get; set; }

    public int EquipeId { get; set; }

    public int? Pontos { get; set; }

    public virtual Chave Chave { get; set; } = null!;

    public virtual Equipe Equipe { get; set; } = null!;

    public virtual Torneio Torneio { get; set; } = null!;
}
