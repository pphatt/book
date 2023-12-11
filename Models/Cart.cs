using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace comic.Models;

public class Cart
{
    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual User User { get; set; } = null!;

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int Quantity { get; set; }
}
