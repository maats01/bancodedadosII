using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Aeroporto
{
    public int Id { get; set; }

    public string NomeAeroporto { get; set; } = null!;

    public string Cidade { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Voo> VooIdAeroportoDestinoNavigations { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooIdAeroportoOrigemNavigations { get; set; } = new List<Voo>();
}
