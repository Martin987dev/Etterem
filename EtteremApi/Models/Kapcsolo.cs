using System;
using System.Collections.Generic;

namespace EtteremApi.Models;

public partial class Kapcsolo
{
    public int KapcsoloId { get; set; }

    public int RendelesId { get; set; }

    public int TermekekId { get; set; }

    public virtual Rendeles Rendeles { get; set; } = null!;

    public virtual Termekek Termekek { get; set; } = null!;
}
