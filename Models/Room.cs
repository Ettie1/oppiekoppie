using System;
using System.Collections.Generic;

namespace oppiekoppie.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomDetail { get; set; } = null!;

    public int RoomNo { get; set; }

    public bool Available { get; set; }
}
