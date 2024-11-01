using System;
using System.Collections.Generic;

namespace oppiekoppie.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string PayType { get; set; } = null!;

    public decimal Owed { get; set; }

    public decimal Paid { get; set; }

    public decimal Balance { get; set; }

    public DateTime PayDate { get; set; }

    public DateTime Date { get; set; }
}
