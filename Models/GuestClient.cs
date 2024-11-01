using System;
using System.Collections.Generic;

namespace oppiekoppie.Models;

public partial class GuestClient
{
    public int GuestClientId { get; set; }

    public string? Title { get; set; }

    public string? Firstname { get; set; }

    public string Lastname { get; set; } = null!;

    public string TownCity { get; set; } = null!;
}
