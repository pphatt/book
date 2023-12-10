using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Publisher
{
    [Key]
    public int PublisherId { get; set; }

    public string PublisherName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
