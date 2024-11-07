using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Pessoa
{
    public int Id { get; set; }

    public string? NomeCompleto { get; set; }

    public virtual ICollection<Passageiro> Passageiros { get; set; } = new List<Passageiro>();

    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
