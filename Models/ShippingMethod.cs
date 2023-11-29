using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class ShippingMethod
{
    public int ShippingMethodId { get; set; }

    public string ShippingMethodName { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
