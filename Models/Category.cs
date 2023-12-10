using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace comic.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
