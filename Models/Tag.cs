using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Tag
{
    [Key]
    public int TagId { get; set; }

    public string TagName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
