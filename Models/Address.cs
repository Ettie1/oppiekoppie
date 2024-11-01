using System;
using System.Collections.Generic;

namespace oppiekoppie.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Street { get; set; }

    public string? Suburb { get; set; }

    public string TownCity { get; set; } = null!;

    public string? Code { get; set; }
}
