using System;
using System.Collections.Generic;

namespace EtteremApi.Models;

public partial class Termekek
{
    public int Id { get; set; }

    public string? Etel { get; set; }

    public int? Arak { get; set; }

    public virtual ICollection<Kapcsolo> Kapcsolos { get; set; } = new List<Kapcsolo>();
}
