using System;
using System.Collections.Generic;

namespace EtteremApi.Models;

public partial class Rendeles
{
    public int Id { get; set; }

    public int? Asztalszam { get; set; }

    public string? Fizetesimod { get; set; }

    public virtual ICollection<Kapcsolo> Kapcsolos { get; set; } = new List<Kapcsolo>();
}
