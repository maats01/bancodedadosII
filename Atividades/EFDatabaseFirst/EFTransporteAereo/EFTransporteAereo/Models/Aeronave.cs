using System;
using System.Collections.Generic;

namespace EFTransporteAereo.Models;

public partial class Aeronave
{
    public int Id { get; set; }

    public string Modelo { get; set; } = null!;

    public int IdFabricante { get; set; }

    public int IdTipo { get; set; }

    public int NumAssentos { get; set; }

    public virtual Fabricante IdFabricanteNavigation { get; set; } = null!;

    public virtual TiposAeronave IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
