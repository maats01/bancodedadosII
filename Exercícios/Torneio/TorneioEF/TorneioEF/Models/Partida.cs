using System;
using System.Collections.Generic;

namespace TorneioEF.Models;

public partial class Partida
{
    public int Id { get; set; }

    public int TorneioId { get; set; }

    public int ChaveId { get; set; }

    public int RodadaId { get; set; }

    public int ModalidadeId { get; set; }

    public bool? Empate { get; set; }

    public DateTime DataPartida { get; set; }

    public virtual Chave Chave { get; set; } = null!;

    public virtual Modalidade Modalidade { get; set; } = null!;

    public virtual ICollection<Partidaequipe> Partidaequipes { get; set; } = new List<Partidaequipe>();

    public virtual Rodada Rodada { get; set; } = null!;

    public virtual Torneio Torneio { get; set; } = null!;
}
