using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Passageiro
{
    public int Id { get; set; }

    public int IdPessoa { get; set; }

    public virtual ICollection<AssentosPassageirosVoo> AssentosPassageirosVoos { get; set; } = new List<AssentosPassageirosVoo>();

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
}
