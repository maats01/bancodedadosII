using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Partidaequipe
{
    public int Id { get; set; }

    public int PartidaId { get; set; }

    public int EquipeId { get; set; }

    public int? Pontos { get; set; }

    public bool? Vencedor { get; set; }

    public virtual Equipe Equipe { get; set; } = null!;

    public virtual Partida Partida { get; set; } = null!;
}
