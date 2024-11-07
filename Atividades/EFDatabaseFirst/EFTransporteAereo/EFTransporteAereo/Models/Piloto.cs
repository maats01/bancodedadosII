using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Piloto
{
    public int Id { get; set; }

    public int IdPessoa { get; set; }

    public virtual Pessoa IdPessoaNavigation { get; set; } = null!;

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
