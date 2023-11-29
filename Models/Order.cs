using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int PaymentId { get; set; }

    public int ShippingMethodId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderTotal { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual ShippingMethod ShippingMethod { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
