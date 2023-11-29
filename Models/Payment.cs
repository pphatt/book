using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string PaymentName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
