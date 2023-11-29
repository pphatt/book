using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
