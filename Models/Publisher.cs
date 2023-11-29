using System;
using System.Collections.Generic;

namespace comic.Models;

public partial class Publisher
{
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
